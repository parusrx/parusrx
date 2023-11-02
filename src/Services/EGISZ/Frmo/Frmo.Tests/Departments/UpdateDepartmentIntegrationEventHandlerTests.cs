// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using ParusRx.Frmo.API.Services;

namespace ParusRx.Frmo.Tests;

public class UpdateDepartmentIntegrationEventHandlerTests
{
    private readonly Mock<IParusRxStore> _storeMock;
    private readonly Mock<IDepartmentService> _serviceMock;
    private readonly Mock<ILogger<UpdateDepartmentIntegrationEventHandler>> _loggerMock;

    public UpdateDepartmentIntegrationEventHandlerTests()
    {
        _storeMock = new Mock<IParusRxStore>();
        _serviceMock = new Mock<IDepartmentService>();
        _loggerMock = new Mock<ILogger<UpdateDepartmentIntegrationEventHandler>>();
    }

    [Fact]
    public async Task HandleAsync_WithValidRequest_SaveDataResponse()
    {
        // Arrange
        MqIntegrationEvent @event = new(Guid.NewGuid().ToString());

        UpdateDepartmentRequest request = new()
        {
            Parameters = new()
            {
                Oid = "1.2.643.5.1.13.13.12.2.77.7799",
                EntityId = "1.2.643.5.1.13.13.12.2.77.7799"
            },
            Content = new()
            {
                Department = new()
                {
                    Oid = "1.2.643.5.1.13.13.12.2.77.7799",
                    DepartName = "Department 1"
                }
            }
        };

        UpdateDepartmentResponse response = new()
        {
            RequestId = Guid.NewGuid().ToString(),
            Message = null
        };

        _storeMock.Setup(s => s.ReadDataRequestAsync(@event.Body)).ReturnsAsync(XmlSerializerUtility.Serialize(request)!);
        _storeMock.Setup(s => s.SaveDataResponseAsync(@event.Body, It.IsAny<byte[]>())).Returns(Task.CompletedTask);
        _serviceMock.Setup(s => s.UpdateAsync(request.Parameters.Oid, request.Parameters.EntityId, request.Content.Department, It.IsAny<CancellationToken>())).ReturnsAsync(response);

        var handler = new UpdateDepartmentIntegrationEventHandler(_storeMock.Object, _serviceMock.Object, _loggerMock.Object);

        // Act
        await handler.HandleAsync(@event);

        // Assert
        _storeMock.Verify(s => s.ReadDataRequestAsync(@event.Body), Times.Once());
        _storeMock.Verify(s => s.SaveDataResponseAsync(@event.Body, It.IsAny<byte[]>()), Times.Once());
        _serviceMock.Verify(s => s.UpdateAsync(request.Parameters.Oid, request.Parameters.EntityId, request.Content.Department, It.IsAny<CancellationToken>()), Times.Once());
    }

    [Fact]
    public async Task HandleAsync_WithException_SaveErrorAndLogError()
    {
        // Arrange
        MqIntegrationEvent @event = new(Guid.NewGuid().ToString());

        _storeMock.Setup(s => s.ReadDataRequestAsync(@event.Body)).ThrowsAsync(new InvalidOperationException());
        
        var handler = new UpdateDepartmentIntegrationEventHandler(_storeMock.Object, _serviceMock.Object, _loggerMock.Object);

        // Act
        await handler.HandleAsync(@event);

        // Assert
        _storeMock.Verify(s => s.ReadDataRequestAsync(@event.Body), Times.Once());
        _storeMock.Verify(s => s.SaveDataResponseAsync(@event.Body, It.IsAny<byte[]>()), Times.Never());
        _serviceMock.Verify(s => s.UpdateAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Department>(), It.IsAny<CancellationToken>()), Times.Never());


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
