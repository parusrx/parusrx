﻿// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API.Handlers;

public class GetByOidDepartmentIntegrationEventHandler(IParusRxStore store, IDepartmentService service, ILogger<GetByOidDepartmentIntegrationEventHandler> logger)
    : IIntegrationEventHandler<MqIntegrationEvent>
{
    public async Task HandleAsync(MqIntegrationEvent @event, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Handling integration event: {IntegrationEventId} - ({IntegrationEvent})", @event.Id, @event);

        string id = @event.Body;

        try
        {
            byte[] data = await store.ReadDataRequestAsync(id);

            var request = XmlSerializerUtility.Deserialize<DefaultRequest>(data)
                ?? throw new InvalidOperationException($"Cannot deserialize request data for integration event: {@event.Id}");

            string departOid = request.Parameters["departOid"]!;
            request.Parameters.Remove("departOid");

            var response = await service.GetAsync(departOid, request.Parameters, cancellationToken);

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