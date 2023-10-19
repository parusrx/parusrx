// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

internal static class PubSubDepartmentEndpoint
{
    public static RouteGroupBuilder MapPubSubDepartments(this IEndpointRouteBuilder endpoints)
    {
        const string daprPubSubName = "pubsub";

        var group = endpoints.MapGroup("api/v1/pubsub/org/depart");

        group.MapPost("/get-by-oid", [Topic(daprPubSubName, "FrmoGetByOidDepartmentIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] GetByOidDepartmentIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/list", [Topic(daprPubSubName, "FrmoListPagedDepartmentIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] ListPagedDepartmentIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/create", [Topic(daprPubSubName, "FrmoCreateDepartmentIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] CreateDepartmentIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/update", [Topic(daprPubSubName, "FrmoUpdateDepartmentIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] UpdateDepartmentIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/delete", [Topic(daprPubSubName, "FrmoDeleteDepartmentIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] DeleteDepartmentIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return group;
    }
}
