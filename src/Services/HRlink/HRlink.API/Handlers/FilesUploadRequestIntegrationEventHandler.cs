// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Handlers;

/// <summary>
/// The files upload request integration event handler.
/// </summary>
/// <param name="store">The Parus RX store.</param>
/// <param name="fileService">The file service.</param>
/// <param name="logger">The logger.</param>
public class FilesUploadRequestIntegrationEventHandler(IParusRxStore store, IFileService fileService, ILogger<FilesUploadRequestIntegrationEventHandler> logger)
    : IIntegrationEventHandler<MqIntegrationEvent>
{
    /// <inheritdoc/>
    public async Task HandleAsync(MqIntegrationEvent @event, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Handling integration event: {IntegrationEventId} - {IntegrationEvent}", @event.Id, @event);

        string id = @event.Body;

        try
        {
            byte[] data = await store.ReadDataRequestAsync(id);
            var filesUploadRequest = XmlSerializerUtility.Deserialize<FilesUploadRequest>(data);
            if (filesUploadRequest is not null)
            {
                var filesUploadResponse = await fileService.UploadAsync(filesUploadRequest, cancellationToken);
                if (filesUploadResponse is not null)
                {
                    byte[]? response = XmlSerializerUtility.Serialize(filesUploadResponse);
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
