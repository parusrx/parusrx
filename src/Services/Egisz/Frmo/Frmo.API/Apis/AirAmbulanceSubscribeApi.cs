// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.API;

public static class AirAmbulanceSubscribeApi
{
    public static IEndpointRouteBuilder MapAirAmbulanceSubscribeApi(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/list", [Topic(daprPubSubName, "ListAirAmbulanceIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, ListAirAmbulanceIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/", [Topic(daprPubSubName, "GetAirAmbulanceIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, GetAirAmbulanceIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/create", [Topic(daprPubSubName, "CreateAirAmbulanceIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, CreateAirAmbulanceIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/update", [Topic(daprPubSubName, "UpdateAirAmbulanceIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, UpdateAirAmbulanceIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/delete", [Topic(daprPubSubName, "DeleteAirAmbulanceIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, DeleteAirAmbulanceIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
