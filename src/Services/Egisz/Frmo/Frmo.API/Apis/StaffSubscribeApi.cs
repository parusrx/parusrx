// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.API;

public static class StaffSubscribeApi
{
    public static IEndpointRouteBuilder MapStaffSubscribeApi(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/", [Topic(daprPubSubName, "FrmoGetStaffIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] ListStaffIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/get", [Topic(daprPubSubName, "FrmoGetStaffByEntityIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] GetStaffIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/create", [Topic(daprPubSubName, "FrmoCreateStaffIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] CreateStaffIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/update", [Topic(daprPubSubName, "FrmoUpdateStaffIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] UpdateStaffIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/delete", [Topic(daprPubSubName, "FrmoDeleteStaffIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] DeleteStaffIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
