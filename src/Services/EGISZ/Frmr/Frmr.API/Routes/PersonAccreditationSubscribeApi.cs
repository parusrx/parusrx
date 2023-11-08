// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Routes;

public static class PersonAccreditationSubscribeApi
{
    public static RouteGroupBuilder MapPersonAccreditationSubscribeHandlers(this IEndpointRouteBuilder routes)
    {
        const string daprPubSubName = "pubsub";

        var group = routes.MapGroup("/subscribe/person/accreditation");

        group.MapPost("/", [Topic(daprPubSubName, "GetPersonAccreditationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, GetPersonAccreditationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/create", [Topic(daprPubSubName, "CreatePersonAccreditationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, CreatePersonAccreditationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/update", [Topic(daprPubSubName, "UpdatePersonAccreditationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, UpdatePersonAccreditationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/delete", [Topic(daprPubSubName, "DeletePersonAccreditationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, DeletePersonAccreditationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return group;
    }
}
