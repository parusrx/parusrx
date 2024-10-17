// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using Moq;

namespace ParusRx.HRlink.API.Tests.Handlers;

public class RouteTemplateRequestIntegrationEventHandlerTests
{
    [Fact]
    public async Task HandleAsync_WithValidRequest_CallsRouteTemplateServiceAndSavesResponse()
    {
        // Arrange
        var @event = new MqIntegrationEvent(Guid.NewGuid().ToString());

        var request = new RouteTemplateRequest
        {
            Authorization = new AuthorizationContext
            {
                Url = "https://demo.hr-link.ru",
                ClientId = "78DB35C3-64E4-4D06-B34D-793070E970C6",
                ApiToken = "81255B76-7F18-46E2-93C0-7ED60BE814F9"
            }
        };
        var response = new RouteTemplateResponse
        {
            Result = true,
            SigningRouteTemplates =
            [
                new SigningRouteTemplate
                {
                    Id = "1",
                    Name = "Route 1"
                }
            ]
        };

        byte[]? data = XmlSerializerUtility.Serialize(request);
        byte[]? responseData = XmlSerializerUtility.Serialize(response);

        var storeMock = new Mock<IParusRxStore>();
        storeMock.Setup(x => x.ReadDataRequestAsync(It.IsAny<string>())).ReturnsAsync(data!);
        storeMock.Setup(x => x.SaveDataResponseAsync(It.IsAny<string>(), It.IsAny<byte[]>())).Returns(Task.CompletedTask);

        var routeTemplateServiceMock = new Mock<IRouteTemplateService>();
        routeTemplateServiceMock.Setup(x => x.GetRouteTemplatesAsync(It.IsAny<RouteTemplateRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);

        var loggerMock = new Mock<ILogger<RouteTemplateRequestIntegrationEventHandler>>();

        var handler = new RouteTemplateRequestIntegrationEventHandler(storeMock.Object, routeTemplateServiceMock.Object, loggerMock.Object);

        // Act
        await handler.HandleAsync(@event);

        // Assert
        storeMock.Verify(x => x.SaveDataResponseAsync(@event.Body, It.IsAny<byte[]>()), Times.Once);
        routeTemplateServiceMock.Verify(x => x.GetRouteTemplatesAsync(
            It.Is<RouteTemplateRequest>(r => true),
            It.Is<CancellationToken>(t => t.Equals(CancellationToken.None))), Times.Once);
        storeMock.Verify(x => x.SaveDataResponseAsync(
            It.Is<string>(id => id == @event.Body),
            It.Is<byte[]>(data => data.SequenceEqual(responseData!))), Times.Once);
    }

    [Fact]
    public async Task HandleAsync_WithInvalidRequest_CallsErrorAsyncAndLogsError()
    {
        // Arrange
        var @event = new MqIntegrationEvent(Guid.NewGuid().ToString());

        var storeMock = new Mock<IParusRxStore>();
        storeMock.Setup(x => x.ReadDataRequestAsync(It.IsAny<string>())).ThrowsAsync(new Exception("Test exception"));

        var routeTemplateServiceMock = new Mock<IRouteTemplateService>();
        var loggerMock = new Mock<ILogger<RouteTemplateRequestIntegrationEventHandler>>();

        var handler = new RouteTemplateRequestIntegrationEventHandler(storeMock.Object, routeTemplateServiceMock.Object, loggerMock.Object);

        // Act
        await handler.HandleAsync(@event);

        // Assert
        storeMock.Verify(x => x.ErrorAsync(It.Is<string>(id => id == @event.Body), It.IsAny<string>()), Times.Once);
        loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((o, t) => o.ToString()!.Contains($"Error handling integration event: {@event.Id} - {@event}")),
                It.IsAny<Exception>(),
                (Func<It.IsAnyType, Exception?, string>)It.IsAny<object>()),
            Times.Once);
    }

}
