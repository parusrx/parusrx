﻿// // Copyright (c) Alexander Bocharov.
// // Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Tests.Handlers;

public class UpdateBuildingIntegrationEventHandlerTests
{
    private readonly Mock<IParusRxStore> _storeMock;
    private readonly Mock<IBuildingService> _serviceMock;
    private readonly Mock<ILogger<UpdateBuildingIntegrationEventHandler>> _loggerMock;

    public UpdateBuildingIntegrationEventHandlerTests()
    {
        _storeMock = new Mock<IParusRxStore>();
        _serviceMock = new Mock<IBuildingService>();
        _loggerMock = new Mock<ILogger<UpdateBuildingIntegrationEventHandler>>();
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

        var response = new DefaultResponse()
        {
            RequestId = Guid.NewGuid().ToString()
        };

        _storeMock.Setup(s => s.ReadDataRequestAsync(@event.Body)).ReturnsAsync(XmlSerializerUtility.Serialize(request)!);
        _storeMock.Setup(s => s.SaveDataResponseAsync(@event.Body, It.IsAny<byte[]>())).Returns(Task.CompletedTask);
        _serviceMock.Setup(s => s.UpdateAsync(request.Parameters, It.IsAny<Building>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);

        var handler = new UpdateBuildingIntegrationEventHandler(_storeMock.Object, _serviceMock.Object, _loggerMock.Object);

        // Act
        await handler.HandleAsync(@event);

        // Assert
        _storeMock.Verify(s => s.ReadDataRequestAsync(@event.Body), Times.Once());
        _storeMock.Verify(s => s.SaveDataResponseAsync(@event.Body, It.IsAny<byte[]>()), Times.Once());
        _serviceMock.Verify(s => s.UpdateAsync(request.Parameters, It.IsAny<Building>(), It.IsAny<CancellationToken>()), Times.Once());
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
        _serviceMock.Setup(s => s.UpdateAsync(request.Parameters, It.IsAny<Building>(), It.IsAny<CancellationToken>())).ThrowsAsync(new Exception());

        var handler = new UpdateBuildingIntegrationEventHandler(_storeMock.Object, _serviceMock.Object, _loggerMock.Object);

        // Act
        await handler.HandleAsync(@event);

        // Assert
        _storeMock.Verify(s => s.ReadDataRequestAsync(@event.Body), Times.Once());
        _storeMock.Verify(s => s.ErrorAsync(@event.Body, It.IsAny<string>()), Times.Once());
        _serviceMock.Verify(s => s.UpdateAsync(request.Parameters, It.IsAny<Building>(), It.IsAny<CancellationToken>()), Times.Once());
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
