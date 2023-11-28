// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.API;

public static class TerritorialDepartSubscribeApi
{
    public static IEndpointRouteBuilder MapTerritorialDepartSubscribeApi(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/list", [Topic(daprPubSubName, "ListTerritorialDepartIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, ListTerritorialDepartIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/", [Topic(daprPubSubName, "GetTerritorialDepartIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, GetTerritorialDepartIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/create", [Topic(daprPubSubName, "CreateTerritorialDepartIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, CreateTerritorialDepartIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/update", [Topic(daprPubSubName, "UpdateTerritorialDepartIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, UpdateTerritorialDepartIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/delete", [Topic(daprPubSubName, "DeleteTerritorialDepartIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, DeleteTerritorialDepartIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
