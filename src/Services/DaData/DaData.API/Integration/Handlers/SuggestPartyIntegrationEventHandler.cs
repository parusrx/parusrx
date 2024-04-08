// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DaData.API.Integration.Handlers;

/// <summary>
/// Represents the suggest party integration event handler.
/// </summary>
public sealed class SuggestPartyIntegrationEventHandler : IIntegrationEventHandler<MqIntegrationEvent>
{
    private readonly ISuggestPartyIntegrationEventService _service;
    private readonly ILogger<SuggestPartyIntegrationEventHandler> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="SuggestPartyIntegrationEventHandler"/> class.
    /// </summary>
    /// <param name="service">The <see cref="IIntegrationEventHandler"/>.</param>
    /// <param name="logger">The logger to use.</param>
    public SuggestPartyIntegrationEventHandler(ISuggestPartyIntegrationEventService service,
        ILogger<SuggestPartyIntegrationEventHandler> logger)
    {
        _service = service;
        _logger = logger;    
    }

    /// <inheritdoc />
    public async Task HandleAsync(MqIntegrationEvent @event, CancellationToken cancellationToken = default)
    {
        using var scope = _logger.BeginScope("Handling integration event {IntegrationEventId} of type {IntegrationEventType}",
            @event.Id, @event.GetType().Name);

        _logger.LogInformation("Handling integration event: {IntegrationEventId} - ({@IntegrationEvent})", @event.Id, @event);

        await _service.FindPartyByIdAsync(@event, cancellationToken); 
    }
}