// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.API;

public static class ResolutionSubscribeApi
{
    public static IEndpointRouteBuilder MapResolutionSubscribeHandlers(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/", [Topic(daprPubSubName, "ListResolutionIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, ListResolutionIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
