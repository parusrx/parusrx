// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.API;

public static class HouseGroundSubscribeApi
{
    public static IEndpointRouteBuilder MapHouseGroundSubscribeApi(this IEndpointRouteBuilder app) 
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/list", [Topic(daprPubSubName, "ListHouseGroundIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, ListHouseGroundIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/", [Topic(daprPubSubName, "GetHouseGroundIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, GetHouseGroundIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/create", [Topic(daprPubSubName, "CreateHouseGroundIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, CreateHouseGroundIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/update", [Topic(daprPubSubName, "UpdateHouseGroundIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, UpdateHouseGroundIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/delete", [Topic(daprPubSubName, "DeleteHouseGroundIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, DeleteHouseGroundIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
