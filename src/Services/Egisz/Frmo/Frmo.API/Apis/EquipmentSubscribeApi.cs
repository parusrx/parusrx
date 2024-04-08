// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.API;

public static class EquipmentSubscribeApi
{
    public static IEndpointRouteBuilder MapEquipmentSubscribeApi(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/list", [Topic(daprPubSubName, "ListEquipmentIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, ListEquipmentIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/", [Topic(daprPubSubName, "GetEquipmentIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, GetEquipmentIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/create", [Topic(daprPubSubName, "CreateEquipmentIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, CreateEquipmentIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/update", [Topic(daprPubSubName, "UpdateEquipmentIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, UpdateEquipmentIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/delete", [Topic(daprPubSubName, "DeleteEquipmentIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, DeleteEquipmentIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
