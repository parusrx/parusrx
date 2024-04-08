// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DaData.Api.Integration;

/// <summary>
/// An implementation of <see cref="ISuggestPartyEventService"/> for integration events with DaData.ru suggestions.
/// </summary>
public class SuggestPartyEventService : ISuggestPartyEventService
{
    private readonly IParusRxStore _store;
    private readonly ISuggestPartyService _service;
    private readonly ILogger<SuggestPartyEventService> _logger;

    /// <summary>
    /// Initializes a new instance of <see cref="SuggestPartyEventService"/> class.
    /// </summary>
    /// <param name="store">The <see cref="IParusRxStore"/>.</param>
    /// <param name="logger">The logger to use.</param>
    public SuggestPartyEventService(IParusRxStore store,
        ISuggestPartyService service,
        ILogger<SuggestPartyEventService> logger)
    {
        _store = store;
        _service = service;
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task FindPartyByIdAsync(IntegrationEvent @event)
    {
        var id = @event.Metadata;

        try
        {
            var data = await _store.ReadDataRequestAsync(id);

            var suggestPartyRequest = XmlSerializerUtility.Deserialize<DaDataSuggestPartyRequest>(data);
            if (suggestPartyRequest == null)
            {
                throw new ArgumentException("Invalid request.");
            }

            var response = await _service.FindByIdAsync(suggestPartyRequest);

            await _store.SaveDataResponseAsync(id, response);
        }
        catch (Exception ex)
        {
            await _store.ErrorAsync(id, ex.Message);

            _logger.LogError(ex, "EXCEPTION ERROR: {message}", ex.Message);
        }
    }
}
