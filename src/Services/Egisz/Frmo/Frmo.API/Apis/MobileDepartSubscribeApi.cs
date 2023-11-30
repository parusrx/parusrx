// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.API;

public static class MobileDepartSubscribeApi
{
    public static IEndpointRouteBuilder MapMobileDepartSubscribeApi(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/list", [Topic(daprPubSubName, "ListMobileDepartsIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, ListMobileDepartIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/", [Topic(daprPubSubName, "GetMobileDepartsIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, GetMobileDepartIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/create", [Topic(daprPubSubName, "CreateMobileDepartsIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, CreateMobileDepartIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/update", [Topic(daprPubSubName, "UpdateMobileDepartsIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, UpdateMobileDepartIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/delete", [Topic(daprPubSubName, "DeleteMobileDepartsIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, DeleteMobileDepartIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
