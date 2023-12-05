// // Copyright (c) The Parus RX Authors. All rights reserved.
// // Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Tests.Handlers;

public class GetLicenseIntegrationEventHandlerTests
{
    private readonly Mock<IParusRxStore> _storeMock;
    private readonly Mock<ILicenseService> _serviceMock;
    private readonly Mock<ILogger<GetLicenseIntegrationEventHandler>> _loggerMock;

    public GetLicenseIntegrationEventHandlerTests()
    {
        _storeMock = new Mock<IParusRxStore>();
        _serviceMock = new Mock<ILicenseService>();
        _loggerMock = new Mock<ILogger<GetLicenseIntegrationEventHandler>>();
    }

    [Fact]
    public async Task HandleAsync_WithValidRequest_SaveDataResponse()
    {
        // Arrange
        MqIntegrationEvent @event = new(Guid.NewGuid().ToString());

        DefaultRequest request = new()
        {
            Parameters = new()
            {
                { "key", "value" }
            }
        };

        var response = new SingleResponse<License>()
        {
            RequestId = Guid.NewGuid().ToString(),
            Content = new License
            {
                Guid = Guid.NewGuid().ToString()
            }
        };

        _storeMock.Setup(s => s.ReadDataRequestAsync(@event.Body)).ReturnsAsync(XmlSerializerUtility.Serialize(request)!);
        _storeMock.Setup(s => s.SaveDataResponseAsync(@event.Body, It.IsAny<byte[]>())).Returns(Task.CompletedTask);
        _serviceMock.Setup(s => s.GetAsync(request.Parameters, It.IsAny<CancellationToken>())).ReturnsAsync(response);

        var handler = new GetLicenseIntegrationEventHandler(_storeMock.Object, _serviceMock.Object, _loggerMock.Object);

        // Act
        await handler.HandleAsync(@event);

        // Assert
        _storeMock.Verify(s => s.ReadDataRequestAsync(@event.Body), Times.Once());
        _storeMock.Verify(s => s.SaveDataResponseAsync(@event.Body, It.IsAny<byte[]>()), Times.Once());
        _serviceMock.Verify(s => s.GetAsync(request.Parameters, It.IsAny<CancellationToken>()), Times.Once());
    }

    [Fact]
    public async Task HandleAsync_WithException_SaveErrorAndLogError()
    {
        // Arrange
        MqIntegrationEvent @event = new(Guid.NewGuid().ToString());

        DefaultRequest request = new()
        {
            Parameters = new()
            {
                { "key", "value" }
            }
        };

        _storeMock.Setup(s => s.ReadDataRequestAsync(@event.Body)).ReturnsAsync(XmlSerializerUtility.Serialize(request)!);
        _storeMock.Setup(s => s.ErrorAsync(@event.Body, It.IsAny<string>())).Returns(Task.CompletedTask);
        _serviceMock.Setup(s => s.GetAsync(request.Parameters, It.IsAny<CancellationToken>())).ThrowsAsync(new Exception());

        var handler = new GetLicenseIntegrationEventHandler(_storeMock.Object, _serviceMock.Object, _loggerMock.Object);

        // Act
        await handler.HandleAsync(@event);

        // Assert
        _storeMock.Verify(s => s.ReadDataRequestAsync(@event.Body), Times.Once());
        _storeMock.Verify(s => s.ErrorAsync(@event.Body, It.IsAny<string>()), Times.Once());
        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((o, t) => o.ToString()!.Contains($"Error handling integration event: {@event.Id} - {@event}")),
                It.IsAny<Exception>(),
                (Func<It.IsAnyType, Exception?, string>)It.IsAny<object>()),
            Times.Once);
    }
}
