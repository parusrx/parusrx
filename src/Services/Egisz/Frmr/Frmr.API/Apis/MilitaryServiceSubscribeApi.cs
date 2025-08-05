// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.API;

public static class MilitaryServiceSubscribeApi
{
    public static IEndpointRouteBuilder MapMilitaryServiceSubscribeHandlers(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/", [Topic(daprPubSubName, "GetMilitaryServiceIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, GetMilitaryServiceIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/create", [Topic(daprPubSubName, "CreateMilitaryServiceIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, CreateMilitaryServiceIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/update", [Topic(daprPubSubName, "UpdateMilitaryServiceIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, UpdateMilitaryServiceIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/delete", [Topic(daprPubSubName, "DeleteMilitaryServiceIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, DeleteMilitaryServiceIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
