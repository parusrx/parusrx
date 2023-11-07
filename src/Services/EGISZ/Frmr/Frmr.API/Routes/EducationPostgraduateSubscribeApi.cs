// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Routes;

public static class EducationPostgraduateSubscribeApi
{
    public static RouteGroupBuilder MapEducationPostgraduateSubscribeHandlers(this IEndpointRouteBuilder routes)
    {
        const string daprPubSubName = "pubsub";

        var group = routes.MapGroup("/subscribe/person/postgraduate");

        group.MapPost("/", [Topic(daprPubSubName, "ListEducationPostgraduateIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, ListEducationPostgraduateIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/create", [Topic(daprPubSubName, "CreateEducationPostgraduateIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, CreateEducationPostgraduateIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/update", [Topic(daprPubSubName, "UpdateEducationPostgraduateIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, UpdateEducationPostgraduateIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/delete", [Topic(daprPubSubName, "DeleteEducationPostgraduateIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, DeleteEducationPostgraduateIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return group;
    }
}
