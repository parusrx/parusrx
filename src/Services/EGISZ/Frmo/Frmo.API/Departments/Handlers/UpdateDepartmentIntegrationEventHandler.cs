// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

public class UpdateDepartmentIntegrationEventHandler(IParusRxStore store, IDepartmentService service, ILogger<UpdateDepartmentIntegrationEventHandler> logger)
    : IIntegrationEventHandler<MqIntegrationEvent>
{
    public async Task HandleAsync(MqIntegrationEvent @event, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Handling integration event: {IntegrationEventId} - ({IntegrationEvent})", @event.Id, @event);

        string id = @event.Body;

        try
        {
            byte[] data = await store.ReadDataRequestAsync(id);

            var request = XmlSerializerUtility.Deserialize<UpdateDepartmentRequest>(data)
                ?? throw new InvalidOperationException($"Cannot deserialize request data for integration event: {@event.Id}");

            var response = await service.UpdateAsync(request.Parameters.Oid, request.Parameters.EntityId, request.Content.Department, cancellationToken);

            var responseBytes = XmlSerializerUtility.Serialize(response)
                ?? throw new InvalidOperationException($"Cannot serialize response data for integration event: {@event.Id}");

            await store.SaveDataResponseAsync(id, responseBytes);
        }
        catch (Exception ex)
        {
            await store.ErrorAsync(id, ex.Message);

            logger.LogError(ex, "Error handling integration event: {IntegrationEventId} - {IntegrationEvent}", @event.Id, @event);
        }
    }
}
