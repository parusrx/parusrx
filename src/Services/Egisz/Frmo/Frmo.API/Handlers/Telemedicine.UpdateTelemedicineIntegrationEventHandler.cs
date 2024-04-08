// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.API.Handlers;

public sealed class UpdateTelemedicineIntegrationEventHandler(IParusRxStore store, ITelemedicineService service, ILogger<UpdateTelemedicineIntegrationEventHandler> logger) : IIntegrationEventHandler<MqIntegrationEvent>
{
    public async Task HandleAsync(MqIntegrationEvent @event, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Handling integration event: {IntegrationEventId} - ({IntegrationEvent})", @event.Id, @event);

        string id = @event.Body;

        try
        {
            byte[] data = await store.ReadDataRequestAsync(id);

            var request = XmlSerializerUtility.Deserialize<DefaultRequest<Telemedicine>>(data)
                ?? throw new InvalidOperationException($"Cannot deserialize request data for integration event: {@event.Id}");

            var response = await service.UpdateAsync(request.Parameters, request.Content, cancellationToken);

            var responseBytes = XmlSerializerUtility.Serialize(response)
                ?? throw new InvalidOperationException($"Cannot serialize response data for integration event: {@event.Id}");

            await store.SaveDataResponseAsync(id, responseBytes);
        }
        catch (Exception ex)
        {
            string message = ex is HttpResponseException httpResponseException && httpResponseException.Value is ProblemDetails problemDetails
                    ? $"{problemDetails.Code} {problemDetails.ReasonPhrase}: {problemDetails.Message}"
                    : ex.Message;

            await store.ErrorAsync(id, message);

            logger.LogError(ex, "Error handling integration event: {IntegrationEventId} - {IntegrationEvent}", @event.Id, @event);
        }
    }
}
