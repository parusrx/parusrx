// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Astral.API.Handlers;

public sealed class CreatePublishEventsRequestIntegrationEventHandler(IParusRxStore store, IEventService eventService, ILogger<CreatePublishEventsRequestIntegrationEventHandler> logger)
    : IIntegrationEventHandler<MqIntegrationEvent>
{
    public async Task HandleAsync(MqIntegrationEvent @event, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Handling integration event: {IntegrationEventId} - {IntegrationEvent}", @event.Id, @event);

        string id = @event.Body;

        try
        {
            byte[] data = await store.ReadDataRequestAsync(id);
            var createPublishEventsRequest = XmlSerializerUtility.Deserialize<CreatePublishEventsRequest>(data);
            if (createPublishEventsRequest is not null)
            {
                var publishEventsResponse = await eventService.PublishEventsAsync(createPublishEventsRequest, cancellationToken);
                if (publishEventsResponse is not null)
                {
                    byte[]? response = XmlSerializerUtility.Serialize(publishEventsResponse);
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
