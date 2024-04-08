// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.API;

public static class SiteSubscribeApi
{
    public static IEndpointRouteBuilder MapSiteSubscribeApi(this IEndpointRouteBuilder app) 
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/list", [Topic(daprPubSubName, "ListSiteIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, ListSiteIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/", [Topic(daprPubSubName, "GetSiteIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, GetSiteIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/create", [Topic(daprPubSubName, "CreateSiteIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, CreateSiteIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/update", [Topic(daprPubSubName, "UpdateSiteIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, UpdateSiteIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/delete", [Topic(daprPubSubName, "DeleteSiteIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, DeleteSiteIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
