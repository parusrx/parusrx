// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DaData.Api.Controllers;

/// <summary>
/// This controller implements integration event logic for DaData.ru interaction.
/// </summary>
[Route("api/v1/[controller]")]
[ApiController]
public class SuggestionsIntegrationEventController : ControllerBase
{
    private const string DAPR_PUBSUB_NAME = "pubsub";
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Initializes a new instance of <see cref="SuggestionsIntegrationEventController"/> class.
    /// </summary>
    /// <param name="serviceProvider">The <see cref="IServiceProvider"/> used to resolve services.</param>
    public SuggestionsIntegrationEventController(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Retrieving a suggestions on a party.
    /// </summary>
    /// <param name="event">The <see cref="IntegrationEvent"/>.</param>
    /// <returns>A <see cref="Task"/> that completes when processing has completed.</returns>
    [HttpPost("party")]
    [Topic(DAPR_PUBSUB_NAME, "DaDataSuggestionsFindByIdPartyIntegrationEvent")]
    public async Task GetParties(IntegrationEvent @event)
    {
        var handler = _serviceProvider.GetRequiredService<SuggestionPartyHandler>();
        await handler.HandleAsync(@event);
    }
}
