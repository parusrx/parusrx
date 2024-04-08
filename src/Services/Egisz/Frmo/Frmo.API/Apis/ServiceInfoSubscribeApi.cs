// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.API;

public static class ServiceInfoSubscribeApi
{
    public static IEndpointRouteBuilder MapServiceInfoSubscribeApi(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/list", [Topic(daprPubSubName, "ListServiceInfoIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, ListServiceInfoIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/create", [Topic(daprPubSubName, "CreateServiceInfoIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, CreateServiceInfoIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/update", [Topic(daprPubSubName, "UpdateServiceInfoIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, UpdateServiceInfoIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/delete", [Topic(daprPubSubName, "DeleteServiceInfoIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, DeleteServiceInfoIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
