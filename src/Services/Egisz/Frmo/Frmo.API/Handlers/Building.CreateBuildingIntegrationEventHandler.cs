// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API.Handlers;

public sealed class CreateBuildingIntegrationEventHandler(
    IParusRxStore store, 
    IBuildingService service, 
    ILogger<CreateBuildingIntegrationEventHandler> logger) : IIntegrationEventHandler<MqIntegrationEvent>
{
    public async Task HandleAsync(MqIntegrationEvent @event, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Handling integration event: {IntegrationEventId} - ({IntegrationEvent})", @event.Id, @event);

        try
        {
            byte[] data = await store.ReadDataRequestAsync(@event.Body);

            var request = XmlSerializerUtility.Deserialize<DefaultRequest<Building>>(data)
                ?? throw new InvalidOperationException($"Cannot deserialize request data for integration event: {@event.Id}");

            var response = await service.CreateAsync(request.Parameters, request.Content, cancellationToken);

            var responseBytes = XmlSerializerUtility.Serialize(response)
                ?? throw new InvalidOperationException($"Cannot serialize response data for integration event: {@event.Id}");

            await store.SaveDataResponseAsync(@event.Body, responseBytes);
        }
        catch (Exception ex)
        {
            string message = ex is HttpResponseException httpResponseException && httpResponseException.Value is ProblemDetails problemDetails 
                    ? $"{problemDetails.Code} {problemDetails.ReasonPhrase}: {problemDetails.Message}"
                    : ex.Message;

            await store.ErrorAsync(@event.Body, message);

            logger.LogError(ex, "Error handling integration event: {IntegrationEventId} - {IntegrationEvent}", @event.Id, @event);
        }
    }
}
