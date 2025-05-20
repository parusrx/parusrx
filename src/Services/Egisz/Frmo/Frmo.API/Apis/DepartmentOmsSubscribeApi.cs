// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.API;

internal static class DepartmentOmsSubscribeApi
{
    public static IEndpointRouteBuilder MapDepartmentOmsSubscribeApi(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";
        app.MapPost("/", [Topic(daprPubSubName, "FrmoGetDepartmentOmsIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] GetDepartmentOmsIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });
        app.MapPost("/list", [Topic(daprPubSubName, "FrmoListPagedDepartmentOmsIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] ListPagedDepartmentOmsIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });
        app.MapPost("/update", [Topic(daprPubSubName, "FrmoUpdateDepartmentOmsIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] UpdateDepartmentOmsIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });
        return app;
    }
}
