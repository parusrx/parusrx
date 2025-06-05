// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.


namespace ParusRx.HRlink.API.Handlers;

public sealed class ApplicationPrintFormFileIntegrationEventHandler(IParusRxStore store, IApplicationPrintFormFileService service, ILogger<ApplicationPrintFormFileIntegrationEventHandler> logger)
        : IIntegrationEventHandler<MqIntegrationEvent>
{
    public async Task HandleAsync(MqIntegrationEvent @event, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Handling integration event: {IntegrationEventId} - {IntegrationEvent}", @event.Id, @event);
        string id = @event.Body;
        try
        {
            byte[] data = await store.ReadDataRequestAsync(id);
            var request = XmlSerializerUtility.Deserialize<PrintFormFileRequest>(data);
            if (request is not null)
            {
                var response = await service.GetPrintFormFileAsync(request, cancellationToken);
                if (response is not null)
                {
                    byte[]? responseData = XmlSerializerUtility.Serialize(response);
                    if (responseData is not null)
                    {
                        await store.SaveDataResponseAsync(id, responseData);
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
