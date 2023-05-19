// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using ParusRx.Xml;

namespace ParusRx.DaData.Api.Integration;

/// <summary>
/// An implementation of <see cref="ISuggestPartyIntegrationEventService"/> for integration events with DaData.ru suggestions.
/// </summary>
public class SuggestPartyIntegrationEventService : ISuggestPartyIntegrationEventService
{
    private readonly IParusRxStore _store;
    private readonly ISuggestPartyService _suggestPartyService;
    private readonly ILogger<SuggestPartyIntegrationEventService> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="SuggestPartyIntegrationEventService"/> class.
    /// </summary>
    /// <param name="store">The <see cref="IParusRxStore"/>.</param>
    /// <param name="service">The <see cref="ISuggestPartyService"/>.</param>
    /// <param name="logger">The logger to use.</param>
    public SuggestPartyIntegrationEventService(IParusRxStore store, ISuggestPartyService service, ILogger<SuggestPartyIntegrationEventService> logger)
    {
        _store = store ?? throw new ArgumentNullException(nameof(store));
        _suggestPartyService = service ?? throw new ArgumentNullException(nameof(service));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc/>
    public async Task FindPartyByIdAsync(IntegrationEvent integrationEvent, CancellationToken cancellationToken = default)
    {
        var id = (string)integrationEvent.Payload;

        try
        {
            var data = await _store.ReadDataRequestAsync(id);

            var suggestPartyRequest = XmlSerializerUtility.Deserialize<DaDataSuggestPartyRequest>(data);
            if (suggestPartyRequest is not null)
            {
                var response = await _suggestPartyService.FindByIdAsync(suggestPartyRequest, cancellationToken);
                await _store.SaveDataResponseAsync(id, response);
            }
        }
        catch (Exception ex)
        {
            await _store.ErrorAsync(id, ex.Message);
            _logger.LogError(ex, "Error while processing integration event {IntegrationEventId} of type {IntegrationEventType}: {message}", integrationEvent.Id, integrationEvent.GetType().Name, ex.Message);
        }
    }
}