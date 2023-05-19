// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.Extensions.Logging;

using ParusRx.DaData.Api.Integration;
using ParusRx.DaData.Api.Integration.Handlers;
using ParusRx.EventBus.Events;

namespace ParusRx.DaData.Api.UnitTests;

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
        IntegrationEvent integrationEvent = new() { Id = Guid.NewGuid() };
        var cancellationToken = new CancellationToken();

        // Act
        await _handler.HandleAsync(integrationEvent, cancellationToken);

        // Assert
        _serviceMock.Verify(x => x.FindPartyByIdAsync(integrationEvent, cancellationToken), Times.Once);
    }

    [Fact]
    public async Task HandleAsync_ShouldLogInformation()
    {
        // Arrange
        var integrationEvent = new IntegrationEvent { Id = Guid.NewGuid() };
        var cancellationToken = new CancellationToken();

        // Act
        await _handler.HandleAsync(integrationEvent, cancellationToken);

        // Assert
        _loggerMock.Verify(x => x.Log(
            It.Is<LogLevel>(l => l == LogLevel.Information),
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString() == $"Handling integration event: {integrationEvent.Id} - ({integrationEvent})"),
            It.IsAny<Exception>(),
            It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)));
    }
}
