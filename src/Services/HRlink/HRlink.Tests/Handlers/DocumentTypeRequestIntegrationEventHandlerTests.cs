// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.Tests.Handlers;

public class DocumentTypeRequestIntegrationEventHandlerTests
{
    [Fact]
    public async Task HandleAsync_ShouldSaveResponseToStore()
    {
        // Arrange
        var @event = new MqIntegrationEvent(Guid.NewGuid().ToString());

        var documentTypesRequest = new DocumentTypesRequest 
        { 
            Url = "https://demo.hr-link.ru", 
            ApiToken = "81255B76-7F18-46E2-93C0-7ED60BE814F9" 
        };

        var documentTypesResponse = new DocumentTypesResponse 
        { 
            Result = true, 
            DocumentTypes = new[] 
            { 
                new DocumentType 
                { 
                    Id = "7CC0C753-0FE9-4153-9EAE-597582292B1B", 
                    Name = "DocumentType", 
                    Visible = true,
                    System = true,
                    Version = 1
                } 
            } 
        };

        var httpClient = new HttpClient(new MockHttpMessageHandler(documentTypesResponse));

        var storeMock = new Mock<IParusRxStore>();
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
        storeMock.Setup(x => x.ReadDataRequestAsync(@event.Body)).ReturnsAsync(XmlSerializerUtility.Serialize(documentTypesRequest));
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.

        var httpClientFactoryMock = new Mock<IHttpClientFactory>();
        httpClientFactoryMock.Setup(x => x.CreateClient(string.Empty)).Returns(httpClient);

        var loggerMock = new Mock<ILogger<DocumentTypeRequestIntegrationEventHandler>>();

        var handler = new DocumentTypeRequestIntegrationEventHandler(storeMock.Object, httpClientFactoryMock.Object, loggerMock.Object);

        // Act
        await handler.HandleAsync(@event);

        // Assert
        storeMock.Verify(x => x.SaveDataResponseAsync(@event.Body, It.IsAny<byte[]>()), Times.Once);
    }

    [Fact]
    public async Task HandleAsync_ShouldLogErrorAndSaveErrorToStore()
    {
        // Arrange
        var @event = new MqIntegrationEvent(Guid.NewGuid().ToString());
        var exception = new Exception("Test exception");

        var storeMock = new Mock<IParusRxStore>();
        storeMock.Setup(x => x.ReadDataRequestAsync(@event.Body)).ThrowsAsync(exception);

        var httpClient = new HttpClient();

        var httpClientFactoryMock = new Mock<IHttpClientFactory>();
        httpClientFactoryMock.Setup(x => x.CreateClient(string.Empty)).Returns(httpClient);

        var loggerMock = new Mock<ILogger<DocumentTypeRequestIntegrationEventHandler>>();

        var handler = new DocumentTypeRequestIntegrationEventHandler(storeMock.Object, httpClientFactoryMock.Object, loggerMock.Object);

        // Act
        await handler.HandleAsync(@event);

        // Assert
        storeMock.Verify(x => x.ErrorAsync(@event.Body, exception.Message), Times.Once);
        loggerMock.Verify(x => x.Log(
            It.Is<LogLevel>(l => l == LogLevel.Error),
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString() == "Test exception"),
            It.IsAny<Exception>(),
            It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Never);
    }
}
