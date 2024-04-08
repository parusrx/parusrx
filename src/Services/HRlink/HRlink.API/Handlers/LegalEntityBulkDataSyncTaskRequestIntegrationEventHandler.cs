// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Handlers;

/// <summary>
/// The legal entity bulk data sync task request integration event handler.
/// </summary>
/// <param name="store">The Parus RX store.</param>
/// <param name="client">The bulk data sync task client.</param>
/// <param name="logger">The logger.</param>
public class LegalEntityBulkDataSyncTaskRequestIntegrationEventHandler(IParusRxStore store, IBulkDataSyncTaskClient client, ILogger<LegalEntityBulkDataSyncTaskRequestIntegrationEventHandler> logger)
    : IIntegrationEventHandler<MqIntegrationEvent>
{
    /// <inheritdoc />
    public async Task HandleAsync(MqIntegrationEvent @event, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Handling integration event: {IntegrationEventId} - {IntegrationEvent}", @event.Id, @event);

        string id = @event.Body;

        try
        {
            byte[] data = await store.ReadDataRequestAsync(id);
            var createLegalEntityListBulkDataSyncTaskRequest = XmlSerializerUtility.Deserialize<CreateLegalEntityListBulkDataSyncTaskRequest>(data);
            if (createLegalEntityListBulkDataSyncTaskRequest is not null)
            {
                var createBulkDataSyncTaskRequest = new CreateBulkDataSyncTaskRequest<LegalEntity>(BulkDataSyncTaskType.LEGAL_ENTITIES, createLegalEntityListBulkDataSyncTaskRequest.LegalEntities);
                var createBulkDataSyncTaskResponse = await client.CreateBulkDataSyncTaskAsync(
                    createLegalEntityListBulkDataSyncTaskRequest.Authorization.Url,
                    createLegalEntityListBulkDataSyncTaskRequest.Authorization.ClientId,
                    createLegalEntityListBulkDataSyncTaskRequest.Authorization.ApiToken,
                    createBulkDataSyncTaskRequest,
                    cancellationToken);

                if (createBulkDataSyncTaskResponse is not null && createBulkDataSyncTaskResponse.Result)
                {
                    await Task.Delay(3000, cancellationToken);

                    var bulkDataSyncTaskResponse = await client.GetFullStatusBulkDataSyncTaskByIdAsync(
                        createLegalEntityListBulkDataSyncTaskRequest.Authorization.Url,
                        createLegalEntityListBulkDataSyncTaskRequest.Authorization.ClientId,
                        createLegalEntityListBulkDataSyncTaskRequest.Authorization.ApiToken,
                        createBulkDataSyncTaskResponse.BulkDataSyncTask.Id,
                        cancellationToken);

                    if (bulkDataSyncTaskResponse is not null)
                    {
                        byte[]? response = XmlSerializerUtility.Serialize(bulkDataSyncTaskResponse);
                        if (response is not null)
                        {
                            await store.SaveDataResponseAsync(id, response);
                        }
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

/// <summary>
/// Represents a create legal entity list bulk data sync task request.
/// </summary>
[XmlRoot("createLegalEntityListBulkDataSyncTaskRequest")]
public record CreateLegalEntityListBulkDataSyncTaskRequest
{
    /// <summary>
    /// Gets or sets the authorization.
    /// </summary>
    [XmlElement("authorization")]
    [JsonPropertyName("authorization")]
    public required AuthorizationContext Authorization { get; init; }

    /// <summary>
    /// Gets or sets the legal entities.
    /// </summary>
    [XmlArray("legalEntities")]
    [XmlArrayItem("legalEntity")]
    [JsonPropertyName("legalEntities")]
    public required LegalEntity[] LegalEntities { get; init; } = Array.Empty<LegalEntity>();
}