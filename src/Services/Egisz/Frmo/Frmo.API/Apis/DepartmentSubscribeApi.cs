// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

internal static class DepartmentSubscribeApi
{
    public static IEndpointRouteBuilder MapDepartmentSubscribeApi(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/get-by-oid", [Topic(daprPubSubName, "FrmoGetByOidDepartmentIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] GetByOidDepartmentIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/list", [Topic(daprPubSubName, "FrmoListPagedDepartmentIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] ListPagedDepartmentIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/create", [Topic(daprPubSubName, "FrmoCreateDepartmentIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] CreateDepartmentIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/update", [Topic(daprPubSubName, "FrmoUpdateDepartmentIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] UpdateDepartmentIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/delete", [Topic(daprPubSubName, "FrmoDeleteDepartmentIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] DeleteDepartmentIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
