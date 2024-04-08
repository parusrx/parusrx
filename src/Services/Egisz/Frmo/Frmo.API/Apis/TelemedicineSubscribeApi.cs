// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.API;

public static class TelemedicineSubscribeApi
{
    public static IEndpointRouteBuilder MapTelemedicineSubscribeApi(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/list", [Topic(daprPubSubName, "ListTelemedicineIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, ListTelemedicineIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/", [Topic(daprPubSubName, "GetTelemedicineIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, GetTelemedicineIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/create", [Topic(daprPubSubName, "CreateTelemedicineIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, CreateTelemedicineIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/update", [Topic(daprPubSubName, "UpdateTelemedicineIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, UpdateTelemedicineIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/delete", [Topic(daprPubSubName, "DeleteTelemedicineIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, DeleteTelemedicineIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
