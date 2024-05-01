// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Astral.API;

public static class EventsSubscribeApi
{
    public static IEndpointRouteBuilder MapEventsSubscribeApi(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/publish-events", [Topic(daprPubSubName, "CreatePublishEventsRequestIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, CreatePublishEventsRequestIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
