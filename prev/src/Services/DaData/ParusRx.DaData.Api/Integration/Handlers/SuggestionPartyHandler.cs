// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DaData.Api.Integration.Handlers;

/// <summary>
/// An implementation of <see cref="IIntegrationEventHandler"/> for DaData.ru interaction.
/// </summary>
public class SuggestionPartyHandler : IIntegrationEventHandler
{
    private readonly ISuggestPartyEventService _daDataSuggestionsService;
    private readonly ILogger<SuggestionPartyHandler> _logger;

    /// <summary>
    /// Initializes a new instance of <see cref="SuggestionPartyHandler"/> class.
    /// </summary>
    /// <param name="daDataSuggestionsService">The <see cref="ISuggestPartyEventService"/>.</param>
    /// <param name="logger">The logger to use.</param>
    public SuggestionPartyHandler(ISuggestPartyEventService daDataSuggestionsService,
        ILogger<SuggestionPartyHandler> logger)
    {
        _daDataSuggestionsService = daDataSuggestionsService;
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task HandleAsync(IntegrationEvent @event)
    {
        using (LogContext.PushProperty("IntegrationEventContext", $"{@event.Id}-{Program.AppName}"))
        {
            _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, Program.AppName, @event);

            await _daDataSuggestionsService.FindPartyByIdAsync(@event);
        }
    }
}
