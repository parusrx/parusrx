// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.API;

public static class BuildingSubscribeApi
{
    public static IEndpointRouteBuilder MapBuildingSubscribeApi(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/list", [Topic(daprPubSubName, "ListBuildingIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, ListBuildingIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/", [Topic(daprPubSubName, "GetBuildingIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, GetBuildingIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/create", [Topic(daprPubSubName, "CreateBuildingIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, CreateBuildingIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/update", [Topic(daprPubSubName, "UpdateBuildingIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, UpdateBuildingIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/delete", [Topic(daprPubSubName, "DeleteBuildingIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, DeleteBuildingIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
