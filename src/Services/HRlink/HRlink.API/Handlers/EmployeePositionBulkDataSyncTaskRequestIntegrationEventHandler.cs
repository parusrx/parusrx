// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Handlers;

/// <summary>
/// Employee position bulk data sync task request integration event handler.
/// </summary>
/// <param name="store">The Parus RX store.</param>
/// <param name="httpClientFactory">The HTTP client factory.</param>
/// <param name="logger">The logger.</param>
public sealed class EmployeePositionBulkDataSyncTaskRequestIntegrationEventHandler(IParusRxStore store, IBulkDataSyncTaskClient client, ILogger<EmployeePositionBulkDataSyncTaskRequestIntegrationEventHandler> logger)
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
            var createEmployeePositionListBulkDataSyncTaskRequest = XmlSerializerUtility.Deserialize<CreateEmployeePositionListBulkDataSyncTaskRequest>(data);
            if (createEmployeePositionListBulkDataSyncTaskRequest is not null)
            {
                var createBulkDataSyncTaskRequest = new CreateBulkDataSyncTaskRequest<EmployeePositionItem>(BulkDataSyncTaskType.EMPLOYEE_POSITIONS, createEmployeePositionListBulkDataSyncTaskRequest.EmployeePositions);
                var createBulkDataSyncTaskResponse = await client.CreateBulkDataSyncTaskAsync(
                    createEmployeePositionListBulkDataSyncTaskRequest.Authorization.Url,
                    createEmployeePositionListBulkDataSyncTaskRequest.Authorization.ClientId,
                    createEmployeePositionListBulkDataSyncTaskRequest.Authorization.ApiToken,
                    createBulkDataSyncTaskRequest,
                    cancellationToken);

                if (createBulkDataSyncTaskResponse is not null && createBulkDataSyncTaskResponse.Result)
                {
                    await Task.Delay(3000, cancellationToken);

                    var bulkDataSyncTaskResponse = await client.GetFullStatusBulkDataSyncTaskByIdAsync(
                        createEmployeePositionListBulkDataSyncTaskRequest.Authorization.Url,
                        createEmployeePositionListBulkDataSyncTaskRequest.Authorization.ClientId,
                        createEmployeePositionListBulkDataSyncTaskRequest.Authorization.ApiToken,
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

            logger.LogError(ex, "Error while processing integration event {IntegrationEventId} of type {IntegrationEventType}: {Message}", @event.Id, @event.GetType().Name, ex.Message);
        }
    }
}

/// <summary>
/// Represents a create employee position list bulk data sync task request.
/// </summary>
[XmlRoot("createEmployeePositionListBulkDataSyncTaskRequest")]
public record CreateEmployeePositionListBulkDataSyncTaskRequest
{
    /// <summary>
    /// Gets or sets the authorization.
    /// </summary>
    [XmlElement("authorization")]
    [JsonPropertyName("authorization")]
    public required AuthorizationContext Authorization { get; init; } = default!;

    /// <summary>
    /// Gets or sets the employee positions.
    /// </summary>
    [XmlArray("employeePositions")]
    [XmlArrayItem("employeePosition")]
    [JsonPropertyName("employeePositions")]
    public required EmployeePositionItem[] EmployeePositions { get; init; } = Array.Empty<EmployeePositionItem>();
}