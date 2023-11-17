// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

internal static class PubSubStaffEndpoint
{
    public static RouteGroupBuilder MapPubSubStaffs(this IEndpointRouteBuilder endpoints)
    {
        const string daprPubSubName = "pubsub";

        var group = endpoints.MapGroup("api/v1/pubsub/org/staff");

        group.MapPost("/", [Topic(daprPubSubName, "FrmoGetStaffIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] GetStaffIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/get", [Topic(daprPubSubName, "FrmoGetStaffByEntityIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] GetByEntityStaffIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/create", [Topic(daprPubSubName, "FrmoCreateStafffIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] CreateStaffIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/update", [Topic(daprPubSubName, "FrmoUpdateStaffIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] UpdateDepartmentIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/delete", [Topic(daprPubSubName, "FrmoDeleteStaffIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] DeleteDepartmentIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return group;
    }
}
