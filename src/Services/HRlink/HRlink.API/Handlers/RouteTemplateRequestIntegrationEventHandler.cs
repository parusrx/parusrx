// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Handlers;

/// <summary>
/// The route template request integration event handler.
/// </summary>
/// <param name="store">The Parus RX store.</param>
/// <param name="service">The route template service.</param>
/// <param name="logger">The logger.</param>
public class RouteTemplateRequestIntegrationEventHandler(IParusRxStore store, IRouteTemplateService service, ILogger<RouteTemplateRequestIntegrationEventHandler> logger)
    : IIntegrationEventHandler<MqIntegrationEvent>
{
    /// </inheritdoc>
    public async Task HandleAsync(MqIntegrationEvent @event, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Handling integration event: {IntegrationEventId} - {IntegrationEvent}", @event.Id, @event);

        string id = @event.Body;

        try
        {
            byte[] data = await store.ReadDataRequestAsync(id);
            var request = XmlSerializerUtility.Deserialize<RouteTemplateRequest>(data);

            if (request is not null)
            {
                var routeTemplateResponse = await service.GetRouteTemplatesAsync(request, cancellationToken);
                if (routeTemplateResponse is not null)
                {
                    byte[]? response = XmlSerializerUtility.Serialize(routeTemplateResponse);
                    if (response is not null)
                    {
                        await store.SaveDataResponseAsync(id, response);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            await store.ErrorAsync(id, ex.Message);
            logger.LogError(ex, "Error handling integration event: {IntegrationEventId} - {IntegrationEvent}", @event.Id, @event);
        }
    }
}
