// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Routes;

public static class EducationExtSubscribeApi
{
    public static RouteGroupBuilder MapEducationExtSubscribeHandlers(this IEndpointRouteBuilder routes)
    {
        const string daprPubSubName = "pubsub";

        var group = routes.MapGroup("/subscribe/person/ext");

        group.MapPost("/", [Topic(daprPubSubName, "ListPagedEducationExtIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, ListPagedEducationExtIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/create", [Topic(daprPubSubName, "CreateEducationExtIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, CreateEducationExtIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/update", [Topic(daprPubSubName, "UpdateEducationExtIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, UpdateEducationExtIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/delete", [Topic(daprPubSubName, "DeleteEducationExtIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, DeleteEducationExtIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return group;
    }
}
