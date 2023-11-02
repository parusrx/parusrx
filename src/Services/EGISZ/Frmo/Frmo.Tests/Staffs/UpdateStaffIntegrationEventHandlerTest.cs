// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using ParusRx.Frmo.API.Services;

namespace ParusRx.Frmo.Tests;

public class UpdateStaffIntegrationEventHandlerTest
{
    private readonly Mock<IParusRxStore> _storeMock;
    private readonly Mock<IStaffService> _serviceMock;
    private readonly Mock<ILogger<UpdateStaffIntegrationEventHandler>> _loggerMock;

    public UpdateStaffIntegrationEventHandlerTest()
    {
        _storeMock = new Mock<IParusRxStore>();
        _serviceMock = new Mock<IStaffService>();
        _loggerMock = new Mock<ILogger<UpdateStaffIntegrationEventHandler>>();
    }

    [Fact]
    public async Task HandleAsync_WithValidRequest_SaveDataResponse()
    {
        // Arrange
        MqIntegrationEvent @event = new(Guid.NewGuid().ToString());

        UpdateStaffRequest request = new()
        {
            Parameters = new()
            {
                Oid = "1.2.643.5.1.13.13.12.2.77.7799",
                EntityId = "1.2.643.5.1.13.13.12.2.77.7799"
            },
            Content = new()
            {
                Staff = new()
                {
                    StaffId = "e50da88c-f7f0-4a8a-bde6-f491c2268abf"
                }
            }
        };

        UpdateStaffResponse response = new()
        {
            RequestId = Guid.NewGuid().ToString(),
            Message = null
        };

        _storeMock.Setup(s => s.ReadDataRequestAsync(@event.Body)).ReturnsAsync(XmlSerializerUtility.Serialize(request)!);
        _storeMock.Setup(s => s.SaveDataResponseAsync(@event.Body, It.IsAny<byte[]>())).Returns(Task.CompletedTask);
        _serviceMock.Setup(s => s.UpdateAsync(request.Parameters.Oid, request.Parameters.EntityId, request.Content.Staff, It.IsAny<CancellationToken>())).ReturnsAsync(response);

        var handler = new UpdateStaffIntegrationEventHandler(_storeMock.Object, _serviceMock.Object, _loggerMock.Object);

        // Act
        await handler.HandleAsync(@event);

        // Assert
        _storeMock.Verify(s => s.ReadDataRequestAsync(@event.Body), Times.Once());
        _storeMock.Verify(s => s.SaveDataResponseAsync(@event.Body, It.IsAny<byte[]>()), Times.Once());
        _serviceMock.Verify(s => s.UpdateAsync(request.Parameters.Oid, request.Parameters.EntityId, request.Content.Staff, It.IsAny<CancellationToken>()), Times.Once());
    }

    [Fact]
    public async Task HandleAsync_WithException_SaveErrorAndLogError()
    {
        // Arrange
        MqIntegrationEvent @event = new(Guid.NewGuid().ToString());

        _storeMock.Setup(s => s.ReadDataRequestAsync(@event.Body)).ThrowsAsync(new InvalidOperationException());
        
        var handler = new UpdateStaffIntegrationEventHandler(_storeMock.Object, _serviceMock.Object, _loggerMock.Object);

        // Act
        await handler.HandleAsync(@event);

        // Assert
        _storeMock.Verify(s => s.ReadDataRequestAsync(@event.Body), Times.Once());
        _storeMock.Verify(s => s.SaveDataResponseAsync(@event.Body, It.IsAny<byte[]>()), Times.Never());
        _serviceMock.Verify(s => s.UpdateAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Staff>(), It.IsAny<CancellationToken>()), Times.Never());


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
