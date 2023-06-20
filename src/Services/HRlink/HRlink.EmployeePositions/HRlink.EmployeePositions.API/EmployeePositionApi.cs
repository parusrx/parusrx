// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Xml.Serialization;

using Dapr;

using ParusRx.EventBus.Events;
using ParusRx.Storage;

namespace ParusRx.HRlink.EmployeePositions.API;

internal static class EmployeePositionApi
{
    private const string DAPR_PUBSUB_NAME = "pubsub";

    public static RouteGroupBuilder MapEmployeePositionApi(this IEndpointRouteBuilder routes) 
    {
        var group = routes.MapGroup("api/v1/employeePositions");
        group.MapPost("/bulkDataSync", [Topic(DAPR_PUBSUB_NAME, "EmployeePositionsBulkDataSyncIntegrationEvent")] async (MqIntegrationEvent @event, IBulkDataSyncClient bulkDataSyncClient, IParusRxStore store, ILoggerFactory loggerFactory) =>
        {
            var logger = loggerFactory.CreateLogger(nameof(EmployeePositionApi));
            logger.LogInformation("Handling integration event: {IntegrationEventId} - {IntegrationEvent}", @event.Id, @event);

            string id = @event.Body;
            try
            {
                byte[] data = await store.ReadDataRequestAsync(id);
                //var createBulkDataSyncTaskRequest = XmlSerializerUtility.Deserialize<CreateBulkDataSyncTaskRequest>(data);
                //if (createBulkDataSyncTaskRequest is not null)
                //{
                //    var employeePositions = createBulkDataSyncTaskRequest.EmployeePositions.ToEmployeePositionItems();
                //    var createBulkDataSyncTaskRequest = new CreateBulkDataSyncTaskRequest<EmployeePositionItem>(BulkDataSyncTaskType.EMPLOYEE_POSITIONS, employeePositions);

                //    var response = await bulkDataSyncClient.CreateBulkDataSyncTaskAsync(
                //        createBulkDataSyncTaskRequest.Authorization.Url,
                //        createBulkDataSyncTaskRequest.Authorization.ClientId,
                //        createBulkDataSyncTaskRequest.Authorization.ApiToken,
                //        createBulkDataSyncTaskRequest);


                //    if (response is not null && response.Result)
                //    {
                //        await Task.Delay(5000);

                //        var bulkDataSyncTaskResponse = await bulkDataSyncClient.GetFullStatusBulkDataSyncTaskById(
                //            createBulkDataSyncTaskRequest.Authorization.Url,
                //            createBulkDataSyncTaskRequest.Authorization.ClientId,
                //            createBulkDataSyncTaskRequest.Authorization.ApiToken,
                //            response.BulkDataSyncTask.Id);
                //    }
                //}
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

[XmlRoot("sendEmployeePositionsBulkDataSyncRequest")]
public sealed record CreateBulkDataSyncTaskRequest
{
    [XmlElement("authorization")]
    public required Authorization Authorization { get; init; }
    [XmlElement("employeePositions")]
    public required EmployeePositionItemsDto EmployeePositions { get; init; }
}

public sealed record Authorization 
{
    [XmlElement("url")]
    public required string Url { get; init; }
    [XmlElement("clientId")]
    public required string ClientId { get; init; }
    [XmlElement("clientSecret")]
    public required string ApiToken { get; init; }
}
