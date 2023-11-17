// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Routes;

public static class FullPersonSubscribeApi
{
    public static RouteGroupBuilder MapFullPersonSubscribeHandlers(this IEndpointRouteBuilder routes)
    {
        const string daprPubSubName = "pubsub";

        var group = routes.MapGroup("/subscribe/person/full");

        group.MapPost("/", [Topic(daprPubSubName, "GetFullPersonIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, GetFullPersonIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return group;
    }
}
