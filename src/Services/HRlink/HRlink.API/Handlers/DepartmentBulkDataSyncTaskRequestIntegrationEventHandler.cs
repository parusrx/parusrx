// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.API.Handlers;

/// <summary>
/// The department bulk data sync task request integration event handler.
/// </summary>
/// <param name="store">The Parus RX store.</param>
/// <param name="client">The bulk data sync task client.</param>
/// <param name="logger">The logger.</param>
/// <seealso cref="IIntegrationEventHandler{MqIntegrationEvent}" />
public sealed class DepartmentBulkDataSyncTaskRequestIntegrationEventHandler(IParusRxStore store, IBulkDataSyncTaskClient client, ILogger<DepartmentBulkDataSyncTaskRequestIntegrationEventHandler> logger)
    : IIntegrationEventHandler<MqIntegrationEvent>
{
    /// <inheritdoc />
    public async Task HandleAsync(MqIntegrationEvent @event, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Handling integration event {IntegrationEventId} of type {IntegrationEventType}.", @event.Id, @event.GetType().Name);

        string id = @event.Body;

        try
        {
            byte[] data = await store.ReadDataRequestAsync(id);
            var createDepartmentListBulkDataSyncTaskRequest = XmlSerializerUtility.Deserialize<CreateDepartmentListBulkDataSyncTaskRequest>(data);
            if (createDepartmentListBulkDataSyncTaskRequest is not null)
            {
                var createBulkDataSyncTaskRequest = new CreateBulkDataSyncTaskRequest<DepartmentDto>(BulkDataSyncTaskType.CLIENT_DEPARTMENTS, createDepartmentListBulkDataSyncTaskRequest.Departments);
                var createBulkDataSyncTaskResponse = await client.CreateBulkDataSyncTaskAsync(
                    createDepartmentListBulkDataSyncTaskRequest.Authorization.Url,
                    createDepartmentListBulkDataSyncTaskRequest.Authorization.ClientId,
                    createDepartmentListBulkDataSyncTaskRequest.Authorization.ApiToken,
                    createBulkDataSyncTaskRequest,
                    cancellationToken);

                if (createBulkDataSyncTaskResponse is not null && createBulkDataSyncTaskResponse.Result)
                {
                    await Task.Delay(3000, cancellationToken);

                    var bulkDataSyncTaskResponse = await client.GetFullStatusBulkDataSyncTaskByIdAsync(
                        createDepartmentListBulkDataSyncTaskRequest.Authorization.Url,
                        createDepartmentListBulkDataSyncTaskRequest.Authorization.ClientId,
                        createDepartmentListBulkDataSyncTaskRequest.Authorization.ApiToken,
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

            logger.LogError(ex, "Error handling integration event {IntegrationEventId} of type {IntegrationEventType}.", @event.Id, @event.GetType().Name);
        }
    }
}

/// <summary>
/// Represents a create department list bulk data sync task request.
/// </summary>
[XmlRoot("createDepartmentListBulkDataSyncTaskRequest")]
public record CreateDepartmentListBulkDataSyncTaskRequest
{
    /// <summary>
    /// Gets or sets the authorization.
    /// </summary>
    [XmlElement("authorization")]
    public required AuthorizationContext Authorization { get; init; } = default!;

    /// <summary>
    /// Gets or sets the departments.
    /// </summary>
    [XmlArray("departments")]
    [XmlArrayItem("department")]
    public required DepartmentDto[] Departments { get; init; } = Array.Empty<DepartmentDto>();
}

/// <summary>
/// Represents a DTO for a department.
/// </summary>
[XmlRoot("department")]
public record DepartmentDto
{
    /// <summary>
    /// Gets or sets the sync types.
    /// </summary>
    [XmlArray("syncTypes")]
    [XmlArrayItem("syncType")]
    [JsonPropertyName("syncTypes")]
    public string[]? SyncTypes { get; init; }

    /// <summary>
    /// Gets or sets the identifier of the parent department associated with the department.
    /// </summary>
    [XmlElement("parentDepartmentId")]
    [JsonPropertyName("parentDepartmentId")]
    public string? ParentDepartmentId { get; init; }

    /// <summary>
    /// Gets or sets the external identifier of the parent department associated with the department.
    /// </summary>
    [XmlElement("parentDepartmentExternalId")]
    [JsonPropertyName("parentDepartmentExternalId")]
    public string? ParentDepartmentExternalId { get; init; }

    /// <summary>
    /// Gets or sets the name of the department.
    /// </summary>
    [XmlElement("name")]
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// Gets or sets the external identifier of the department.
    /// </summary>
    [XmlElement("externalId")]
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; init; }

    /// <summary>
    /// Gets or sets the identifier of the legal entity associated with the department.
    /// </summary>
    [XmlElement("legalEntityId")]
    [JsonPropertyName("legalEntityId")]
    public string? LegalEntityId { get; set; }

    /// <summary>
    /// Gets or sets the external identifier of the legal entity associated with the department.
    /// </summary>
    [XmlElement("legalEntityExternalId")]
    [JsonPropertyName("legalEntityExternalId")]
    public string? LegalEntityExternalId { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the head manager associated with the department.
    /// </summary>
    [XmlElement("headManagerId")]
    [JsonPropertyName("headManagerId")]
    public string? HeadManagerId { get; set; }

    /// <summary>
    /// Gets or sets the external identifier of the head manager associated with the department.
    /// </summary>
    [XmlElement("headManagerExternalId")]
    [JsonPropertyName("headManagerExternalId")]
    public string? HeadManagerExternalId { get; set; }
}