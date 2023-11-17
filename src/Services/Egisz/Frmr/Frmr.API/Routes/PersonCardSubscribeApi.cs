// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Routes;

public static class PersonCardSubscribeApi
{
    public static RouteGroupBuilder MapPersonCardSubscribeHandlers(this IEndpointRouteBuilder routes)
    {
        const string daprPubSubName = "pubsub";

        var group = routes.MapGroup("/subscribe/person/card");

        group.MapPost("/", [Topic(daprPubSubName, "ListPersonCardIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, ListPersonCardIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/create", [Topic(daprPubSubName, "CreatePersonCardIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, CreatePersonCardIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/update", [Topic(daprPubSubName, "UpdatePersonCardIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, UpdatePersonCardIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/delete", [Topic(daprPubSubName, "DeletePersonCardIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, DeletePersonCardIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return group;
    }
}
