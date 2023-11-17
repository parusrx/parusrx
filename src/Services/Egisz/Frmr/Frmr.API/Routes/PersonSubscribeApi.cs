// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Routes;

public static class PersonSubscribeApi
{
    public static RouteGroupBuilder MapPersonSubscribeHandlers(this IEndpointRouteBuilder routes)
    {
        const string daprPubSubName = "pubsub";

        var group = routes.MapGroup("/subscribe/person");

        group.MapPost("/list", [Topic(daprPubSubName, "ListPagedPersonIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, ListPagedPersonIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/", [Topic(daprPubSubName, "GetPersonIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, GetPersonIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/create", [Topic(daprPubSubName, "CreatePersonIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, CreatePersonIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/update", [Topic(daprPubSubName, "UpdatePersonIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, UpdatePersonIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/delete", [Topic(daprPubSubName, "DeletePersonIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, DeletePersonIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return group;
    }
}
