// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Handlers;

/// <summary>
/// The send to signing integration event handler.
/// </summary>
/// <param name="store">The Parus RX store.</param>
/// <param name="documentService">The document service.</param>
/// <param name="logger">The logger.</param>
public class SendToSigningIntegrationEventHandler(IParusRxStore store, IDocumentService documentService, ILogger<SendToSigningIntegrationEventHandler> logger)
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
            var sendToSigningRequest = XmlSerializerUtility.Deserialize<SendToSigningRequest>(data);
            if (sendToSigningRequest is not null)
            {
                var sendToSigningResponse = await documentService.SendToSigningAsync(sendToSigningRequest, cancellationToken);
                if (sendToSigningResponse is not null)
                {
                    byte[]? response = XmlSerializerUtility.Serialize(sendToSigningResponse);
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
