// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Routes;

public static class EducationProfSubscribeApi
{
    public static RouteGroupBuilder MapEducationProfSubscribeHandlers(this IEndpointRouteBuilder routes)
    {
        const string daprPubSubName = "pubsub";

        var group = routes.MapGroup("/subscribe/person/prof");

        group.MapPost("/", [Topic(daprPubSubName, "GetEducationProfIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, GetEducationProfIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/create", [Topic(daprPubSubName, "CreateEducationProfIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, CreateEducationProfIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/update", [Topic(daprPubSubName, "UpdateEducationProfIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, UpdateEducationProfIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/delete", [Topic(daprPubSubName, "DeleteEducationProfIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, DeleteEducationProfIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return group;
    }
}
