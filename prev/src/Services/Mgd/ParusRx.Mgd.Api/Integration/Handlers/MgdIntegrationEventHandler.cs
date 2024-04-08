// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Integration.Handlers;

/// <summary>
/// Provides methods for an MGD integration event handler.
/// </summary>
public class MgdIntegrationEventHandler : IIntegrationEventHandler
{
    private readonly IMgdIntegrationEventService _mgdIntegrationEventService;
    private readonly ILogger<MgdIntegrationEventHandler> _logger;

    /// <summary>
    /// Initializes a new instance of <see cref="MgdIntegrationEventHandler"/>.
    /// </summary>
    /// <param name="mgdIntegrationEventService">The <see cref="IMgdIntegrationEventService"/>.</param>
    /// <param name="logger">The logger to use.</param>
    public MgdIntegrationEventHandler(IMgdIntegrationEventService mgdIntegrationEventService,
        ILogger<MgdIntegrationEventHandler> logger)
    {
        _mgdIntegrationEventService = mgdIntegrationEventService;
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task HandleAsync(IntegrationEvent @event)
    {
        using (LogContext.PushProperty("IntegrationEventContext", $"{@event.Id}-{Program.AppName}"))
        {
            _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, Program.AppName, @event);

            await _mgdIntegrationEventService.GetMessageAsync(@event);
        }
    }
}
