// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.Tests;

public class GetByOidOrganizationIntegrationEventHandlerTests
{
    private readonly Mock<IParusRxStore> _storeMock;
    private readonly Mock<IOrganizationService> _serviceMock;
    private readonly Mock<ILogger<GetByOidOrganizationIntegrationEventHandler>> _loggerMock;

    public GetByOidOrganizationIntegrationEventHandlerTests()
    {
        _storeMock = new Mock<IParusRxStore>();
        _serviceMock = new Mock<IOrganizationService>();
        _loggerMock = new Mock<ILogger<GetByOidOrganizationIntegrationEventHandler>>();
    }

    [Fact]
    public async Task HandleAsync_WithValidRequest_SaveDataResponse()
    {
        // Arrange
        MqIntegrationEvent @event = new(Guid.NewGuid().ToString());
        GetByOidOrganizationRequest request = new()
        {
            Parameters = new()
            {
                Oid = "1.2.643.5.1.13.13.12.2.78.6258"
            }
        };
        GetByOidOrganizationResponse response = new()
        {
            RequestId = Guid.NewGuid().ToString(),
            Message = null,
            Content = new Organization
            {
                Oid = request.Parameters.Oid
            }
        };

        _storeMock.Setup(s => s.ReadDataRequestAsync(@event.Body)).ReturnsAsync(XmlSerializerUtility.Serialize(request)!);
        _storeMock.Setup(s => s.SaveDataResponseAsync(@event.Body, It.IsAny<byte[]>())).Returns(Task.CompletedTask);
        _serviceMock.Setup(s => s.GetByOidAsync(request.Parameters.Oid, It.IsAny<CancellationToken>())).ReturnsAsync(response);
        
        var handler = new GetByOidOrganizationIntegrationEventHandler(_storeMock.Object, _serviceMock.Object, _loggerMock.Object);

        // Act
        await handler.HandleAsync(@event);

        // Assert
        _storeMock.Verify(s => s.ReadDataRequestAsync(@event.Body), Times.Once());
        _storeMock.Verify(s => s.SaveDataResponseAsync(@event.Body, It.IsAny<byte[]>()), Times.Once());
        _serviceMock.Verify(s => s.GetByOidAsync(request.Parameters.Oid, It.IsAny<CancellationToken>()), Times.Once());
    }

    [Fact]
    public async Task HandleAsync_WithException_SaveErrorAndLogError()
    {
        // Arrange
        MqIntegrationEvent @event = new(Guid.NewGuid().ToString());

        _storeMock.Setup(s => s.ReadDataRequestAsync(@event.Body)).ThrowsAsync(new InvalidOperationException());
        
        var handler = new GetByOidOrganizationIntegrationEventHandler(_storeMock.Object, _serviceMock.Object, _loggerMock.Object);

        // Act
        await handler.HandleAsync(@event);

        // Assert
        _storeMock.Verify(x => x.ErrorAsync(@event.Body, It.IsAny<string>()), Times.Once());
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
