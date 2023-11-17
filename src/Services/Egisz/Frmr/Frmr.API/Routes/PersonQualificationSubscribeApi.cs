// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Routes;

public static class PersonQualificationSubscribeApi
{
    public static RouteGroupBuilder MapPersonQualificationSubscribeHandlers(this IEndpointRouteBuilder routes)
    {
        const string daprPubSubName = "pubsub";

        var group = routes.MapGroup("/subscribe/person/qualification");

        group.MapPost("/", [Topic(daprPubSubName, "ListPersonQualificationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, ListPersonQualificationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/create", [Topic(daprPubSubName, "CreatePersonQualificationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, CreatePersonQualificationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/update", [Topic(daprPubSubName, "UpdatePersonQualificationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, UpdatePersonQualificationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/delete", [Topic(daprPubSubName, "DeletePersonQualificationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, DeletePersonQualificationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return group;
    }
}
