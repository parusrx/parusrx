// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.Extensions.Logging;
using ParusRx.DaData.API.Integration;
using ParusRx.DaData.API.Integration.Handlers;
using ParusRx.EventBus;

namespace ParusRx.DaData.UnitTests;

public class SuggestPartyIntegrationEventHandlerTests
{
    private readonly Mock<ISuggestPartyIntegrationEventService> _serviceMock;
    private readonly Mock<ILogger<SuggestPartyIntegrationEventHandler>> _loggerMock;
    private readonly SuggestPartyIntegrationEventHandler _handler;

    public SuggestPartyIntegrationEventHandlerTests()
    {
        _serviceMock = new Mock<ISuggestPartyIntegrationEventService>();
        _loggerMock = new Mock<ILogger<SuggestPartyIntegrationEventHandler>>();

        _handler = new SuggestPartyIntegrationEventHandler(_serviceMock.Object, _loggerMock.Object);
    }

    [Fact]
    public async Task HandleAsync_ShouldCallFindPartyByIdAsync()
    {
        // Arrange
        var @event = new MqIntegrationEvent(Guid.NewGuid().ToString());
        var cancellationToken = new CancellationToken();

        // Act
        await _handler.HandleAsync(@event, cancellationToken);

        // Assert
        _serviceMock.Verify(x => x.FindPartyByIdAsync(@event, cancellationToken), Times.Once);
    }

    [Fact]
    public async Task HandleAsync_ShouldLogInformation()
    {
        // Arrange
        var @event = new MqIntegrationEvent(Guid.NewGuid().ToString());
        var cancellationToken = new CancellationToken();

        // Act
        await _handler.HandleAsync(@event, cancellationToken);

        // Assert
        _loggerMock.Verify(x => x.Log(
            It.Is<LogLevel>(l => l == LogLevel.Information),
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString() == $"Handling integration event: {@event.Id} - ({@event})"),
            It.IsAny<Exception>(),
            It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)));
    }
}
