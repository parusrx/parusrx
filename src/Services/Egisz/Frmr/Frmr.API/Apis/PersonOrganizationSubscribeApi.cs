// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Routes;

public static class PersonOrganizationSubscribeApi
{
    public static IEndpointRouteBuilder MapPersonOrganizationSubscribeHandlers(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/", [Topic(daprPubSubName, "ListPersonOrganizationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, ListPersonOrganizationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/create", [Topic(daprPubSubName, "CreatePersonOrganizationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, CreatePersonOrganizationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/update", [Topic(daprPubSubName, "UpdatePersonOrganizationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, UpdatePersonOrganizationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/delete", [Topic(daprPubSubName, "DeletePersonOrganizationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, DeletePersonOrganizationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
