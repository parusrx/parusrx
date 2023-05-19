// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DaData.Api.Integration.Handlers;

public class SuggestPartyIntegrationEventHandler : IIntegrationEventHandler
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
    public async Task HandleAsync(IntegrationEvent integrationEvent, CancellationToken cancellationToken = default)
    {
        using var scope = _logger.BeginScope("Handling integration event {IntegrationEventId} of type {IntegrationEventType}",
            integrationEvent.Id, integrationEvent.GetType().Name);

        _logger.LogInformation("Handling integration event: {IntegrationEventId} - ({@IntegrationEvent})", integrationEvent.Id, integrationEvent);

        await _service.FindPartyByIdAsync(integrationEvent, cancellationToken); 
    }
}