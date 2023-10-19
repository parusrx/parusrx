// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.Tests.Handlers;

public class CreateDocumentGroupIntegrationEventHandlerTests
{
    [Fact]
    public async Task HandleAsync_WithValidRequest_CallsDocumentServiceAndSavesResponse()
    {
        // Arrange
        var @event = new MqIntegrationEvent(Guid.NewGuid().ToString());

        var request = new CreateDocumentGroupRequest
        {
            Authorization = new AuthorizationContext
            {
                Url = "https://demo.hr-link.ru",
                ClientId = "78DB35C3-64E4-4D06-B34D-793070E970C6",
                ApiToken = "81255B76-7F18-46E2-93C0-7ED60BE814F9"
            },
            DocumentGroup = new DocumentGroupRequestItem
            {
                Name = "Test",
                CreatorExternalId = "1",
                Documents =
                [
                    new()
                    {
                        ExternalId = "1"
                    }
                ]
            }
        };
        var response = new CreateDocumentGroupResponse
        {
            Result = true,
            DocumentGroup = new DocumentGroupResultItem
            {
                Id = "D7DFEB89-2883-4DFB-8D89-86B7CAFA3827",
                Documents =
                [
                    new DocumentResultItem
                    {
                        Id = "S7DFAB99-48W3-5SF1-90G9-36AS2OFA3828"
                    }
                ]
            }
        };

        byte[]? data = XmlSerializerUtility.Serialize(request);
        byte[]? responseData = XmlSerializerUtility.Serialize(response);

        var storeMock = new Mock<IParusRxStore>();
        storeMock.Setup(x => x.ReadDataRequestAsync(It.IsAny<string>())).ReturnsAsync(data!);
        storeMock.Setup(x => x.SaveDataResponseAsync(It.IsAny<string>(), It.IsAny<byte[]>())).Returns(Task.CompletedTask);

        var documentServiceMock = new Mock<IDocumentService>();
        documentServiceMock.Setup(x => x.CreateDocumentGroupAsync(It.IsAny<CreateDocumentGroupRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);

        var loggerMock = new Mock<ILogger<CreateDocumentGroupIntegrationEventHandler>>();

        var handler = new CreateDocumentGroupIntegrationEventHandler(storeMock.Object, documentServiceMock.Object, loggerMock.Object);

        // Act
        await handler.HandleAsync(@event);

        // Assert
        storeMock.Verify(x => x.ReadDataRequestAsync(It.Is<string>(id => id == @event.Body)), Times.Once);
        documentServiceMock.Verify(x => x.CreateDocumentGroupAsync(
            It.Is<CreateDocumentGroupRequest>(r => true),
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

        var documentServiceMock = new Mock<IDocumentService>();
        var loggerMock = new Mock<ILogger<CreateDocumentGroupIntegrationEventHandler>>();

        var handler = new CreateDocumentGroupIntegrationEventHandler(storeMock.Object, documentServiceMock.Object, loggerMock.Object);

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
