// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.EmployeePositions.API.BulkDataSync;

internal static class BulkDataSyncApi
{
    private const string DAPR_PUBSUB_NAME = "pubsub";

    public static RouteGroupBuilder MapBulkDataSyncApi(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("api/v1/employeePositions");
        group.MapPost("/bulkDataSync", [Topic(DAPR_PUBSUB_NAME, "EmployeePositionsBulkDataSyncIntegrationEvent")] async (MqIntegrationEvent @event, IBulkDataSyncTaskClient bulkDataSyncClient, IParusRxStore store, ILoggerFactory loggerFactory) =>
        {
            var logger = loggerFactory.CreateLogger(nameof(BulkDataSyncApi));
            logger.LogInformation("Handling integration event: {IntegrationEventId} - {IntegrationEvent}", @event.Id, @event);

            string id = @event.Body;
            try
            {
                byte[] data = await store.ReadDataRequestAsync(id);
                var taskRequest = XmlSerializerUtility.Deserialize<CreateEmployeePositionsBulkDataSyncTaskRequest>(data);
                if (taskRequest is not null)
                {
                    var employeePositions = taskRequest.EmployeePositions.ToEmployeePositionItems();
                    var createBulkDataSyncTaskRequest = new CreateBulkDataSyncTaskRequest<EmployeePositionItem>(BulkDataSyncTaskType.EMPLOYEE_POSITIONS, employeePositions);

                    var authorization = taskRequest.Authorization;

                    var createBulkDataSyncTaskResponse = await bulkDataSyncClient.CreateBulkDataSyncTaskAsync(
                        authorization.Url, 
                        authorization.ClientId, 
                        authorization.ApiToken, 
                        createBulkDataSyncTaskRequest);
                }
            }
            catch (Exception ex)
            {
                await store.ErrorAsync(id, ex.Message);
                logger.LogError(ex, "Error while processing integration event {IntegrationEventId} of type {IntegrationEventType}: {Message}", @event.Id, @event.GetType().Name, ex.Message);
            }

            return TypedResults.Created();
        });
        return group;
    }
}
