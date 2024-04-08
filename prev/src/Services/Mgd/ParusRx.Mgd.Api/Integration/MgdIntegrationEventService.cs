// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Integration;

/// <summary>
/// Provides a default implementation for the MGD integration event service.
/// </summary>
public class MgdIntegrationEventService : IMgdIntegrationEventService
{
    private readonly IParusRxStore _store;
    private readonly IMgdIntegrationService _mgdIntegrationService;
    private readonly ILogger<MgdIntegrationEventService> _logger;

    /// <summary>
    /// Initializes a new instance of <see cref="MgdIntegrationEventService"/>.
    /// </summary>
    /// <param name="store">The <see cref="IParusRxStore"/>.</param>
    /// <param name="mgdIntegrationService">The <see cref="IMgdIntegrationService"/>.</param>
    /// <param name="logger">The logger to use.</param>
    public MgdIntegrationEventService(IParusRxStore store,
        IMgdIntegrationService mgdIntegrationService,
        ILogger<MgdIntegrationEventService> logger)
    {
        _store = store;
        _mgdIntegrationService = mgdIntegrationService;
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task GetMessageAsync(IntegrationEvent @event)
    {
        var id = @event.Metadata;

        try
        {
            var data = await _store.ReadDataRequestAsync(id);

            var messageRequest = XmlSerializerUtility.Deserialize<MgdMessageRequest>(data);
            if (messageRequest == null)
            {
                throw new ArgumentException("Invalid request.");
            }

            if (messageRequest.Credential == null)
            {
                throw new ArgumentException("Invalid credentials.");
            }

            var result = await _mgdIntegrationService.GetMessageAsync(messageRequest.Credential);

            if (result.Succeeded)
            {
                await _store.SaveDataResponseAsync(id, null);
            }
            else
            {
                await _store.ErrorAsync(id, result.Error);
            }
        }
        catch (HttpRequestException ex)
        {
            await _store.ErrorAsync(id, $"{ex.StatusCode}. {ex.Message}");

            _logger.LogError(ex, "EXCEPTION ERROR: {message}", ex.Message);
        }
        catch (Exception ex)
        {
            await _store.ErrorAsync(id, ex.Message);

            _logger.LogError(ex, "EXCEPTION ERROR: {message}", ex.Message);
        }
    }
}
