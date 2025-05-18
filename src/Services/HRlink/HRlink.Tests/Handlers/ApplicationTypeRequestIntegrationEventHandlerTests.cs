// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Tests.Handlers;

public class ApplicationTypeRequestIntegrationEventHandlerTests
{
    [Fact]
    public async Task HandleAsync_WithValidRequest_CallsApplicationTypeServiceAndSavesResponse()
    {
        // Arrange
        var @event = new MqIntegrationEvent(Guid.NewGuid().ToString());

        var request = new ApplicationTypeRequest
        {
            Authorization = new AuthorizationContext
            {
                Url = "https://demo.hr-link.ru",
                ClientId = "78DB35C3-64E4-4D06-B34D-793070E970C6",
                ApiToken = "81255B76-7F18-46E2-93C0-7ED60BE814F9"
            }
        };
        var response = new ApplicationTypeResponse
        { 
            ApplicationTypes = new[] 
            { 
                new ApplicationType 
                { 
                    Id = "1", 
                    Name = "Test" 
                } 
            }, 
            Result = true 
        };

        byte[]? data = XmlSerializerUtility.Serialize(request);
        byte[]? responseData = XmlSerializerUtility.Serialize(response);

        var storeMock = new Mock<IParusRxStore>();
        storeMock.Setup(x => x.ReadDataRequestAsync(It.IsAny<string>())).ReturnsAsync(data!);
        storeMock.Setup(x => x.SaveDataResponseAsync(It.IsAny<string>(), It.IsAny<byte[]>())).Returns(Task.CompletedTask);

        var applicationTypeServiceMock = new Mock<IApplicationTypeService>();
        applicationTypeServiceMock.Setup(x => x.GetApplicationTypesAsync(It.IsAny<ApplicationTypeRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);

        var loggerMock = new Mock<ILogger<ApplicationTypeRequestIntegrationEventHandler>>();

        var handler = new ApplicationTypeRequestIntegrationEventHandler(storeMock.Object, applicationTypeServiceMock.Object, loggerMock.Object);

        // Act
        await handler.HandleAsync(@event);

        // Assert
        storeMock.Verify(x => x.SaveDataResponseAsync(@event.Body, It.IsAny<byte[]>()), Times.Once);
        applicationTypeServiceMock.Verify(x => x.GetApplicationTypesAsync(
            It.Is<ApplicationTypeRequest>(r => true),
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

        var applicationTypeServiceMock = new Mock<IApplicationTypeService>();
        var loggerMock = new Mock<ILogger<ApplicationTypeRequestIntegrationEventHandler>>();

        var handler = new ApplicationTypeRequestIntegrationEventHandler(storeMock.Object, applicationTypeServiceMock.Object, loggerMock.Object);

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
