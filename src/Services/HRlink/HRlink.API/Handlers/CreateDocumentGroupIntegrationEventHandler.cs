// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.API.Handlers;

/// <summary>
/// The create document group integration event handler.
/// </summary>
/// <param name="store">The Parus RX store.</param>
/// <param name="documentService">The document service.</param>
/// <param name="logger">The logger.</param>
public class CreateDocumentGroupIntegrationEventHandler(IParusRxStore store, IDocumentService documentService, ILogger<CreateDocumentGroupIntegrationEventHandler> logger)
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
            var createDocumentGroupRequest = XmlSerializerUtility.Deserialize<CreateDocumentGroupRequest>(data);
            if (createDocumentGroupRequest is not null)
            {
                var createDocumentGroupResponse = await documentService.CreateDocumentGroupAsync(createDocumentGroupRequest, cancellationToken);
                if (createDocumentGroupResponse is not null)
                {
                    byte[]? response = XmlSerializerUtility.Serialize(createDocumentGroupResponse);
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
