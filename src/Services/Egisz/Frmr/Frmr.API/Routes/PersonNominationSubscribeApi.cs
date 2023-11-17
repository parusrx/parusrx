// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Routes;

public static class PersonNominationSubscribeApi
{
    public static RouteGroupBuilder MapPersonNominationSubscribeHandlers(this IEndpointRouteBuilder routes)
    {
        const string daprPubSubName = "pubsub";

        var group = routes.MapGroup("/subscribe/person/nomination");

        group.MapPost("/", [Topic(daprPubSubName, "ListPersonNominationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, ListPersonNominationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/create", [Topic(daprPubSubName, "CreatePersonNominationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, CreatePersonNominationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/update", [Topic(daprPubSubName, "UpdatePersonNominationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, UpdatePersonNominationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/delete", [Topic(daprPubSubName, "DeletePersonNominationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, DeletePersonNominationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return group;
    }
}
