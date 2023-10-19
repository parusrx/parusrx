// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.API.Handlers;

/// <summary>
/// The user bulk data sync task request integration event handler.
/// </summary>
/// <param name="store">The Parus RX store.</param>
/// <param name="client">The bulk data sync task client.</param>
/// <param name="logger">The logger.</param>
public sealed class UserBulkDataSyncTaskRequestIntegrationEventHandler(IParusRxStore store, IBulkDataSyncTaskClient client, ILogger<UserBulkDataSyncTaskRequestIntegrationEventHandler> logger)
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
            var createUserListBulkDataSyncTaskRequest = XmlSerializerUtility.Deserialize<CreateUserListBulkDataSyncTaskRequest>(data);
            if (createUserListBulkDataSyncTaskRequest is not null)
            {
                var createBulkDataSyncTaskRequest = new CreateBulkDataSyncTaskRequest<User>(BulkDataSyncTaskType.CLIENT_USERS, createUserListBulkDataSyncTaskRequest.Users);
                var createBulkDataSyncTaskResponse = await client.CreateBulkDataSyncTaskAsync(
                    createUserListBulkDataSyncTaskRequest.Authorization.Url,
                    createUserListBulkDataSyncTaskRequest.Authorization.ClientId,
                    createUserListBulkDataSyncTaskRequest.Authorization.ApiToken,
                    createBulkDataSyncTaskRequest,
                    cancellationToken);

                if (createBulkDataSyncTaskResponse is not null && createBulkDataSyncTaskResponse.Result) 
                {
                    await Task.Delay(3000, cancellationToken);

                    var bulkDataSyncTaskResponse = await client.GetFullStatusBulkDataSyncTaskByIdAsync(
                        createUserListBulkDataSyncTaskRequest.Authorization.Url,
                        createUserListBulkDataSyncTaskRequest.Authorization.ClientId,
                        createUserListBulkDataSyncTaskRequest.Authorization.ApiToken,
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
/// Represents a create user list bulk data sync task request.
/// </summary>
[XmlRoot("createUserListBulkDataSyncTaskRequest")]
public record CreateUserListBulkDataSyncTaskRequest
{
    /// <summary>
    /// Gets or sets the authorization.
    /// </summary>
    [XmlElement("authorization")]
    public required AuthorizationContext Authorization { get; init; } = default!;

    /// <summary>
    /// Gets or sets the users.
    /// </summary>
    [XmlArray("users")]
    [XmlArrayItem("user")]
    public required User[] Users { get; init; } = Array.Empty<User>();
}