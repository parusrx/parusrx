// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

internal static class PubSubOrganizationEndpoint
{
    public static RouteGroupBuilder MapPubSubOrganizations(this IEndpointRouteBuilder endpoints)
    {
        const string daprPubSubName = "pubsub";
        
        var group = endpoints.MapGroup("api/v1/pubsub/org");

        group.MapPost("/get-by-oid", [Topic(daprPubSubName, "FrmoGetByOidOrganizationIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] GetByOidOrganizationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/list", [Topic(daprPubSubName, "FrmoListPagedOrganizationIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] ListPagedOrganizationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/update", [Topic(daprPubSubName, "FrmoUpdateOrganizationIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] UpdateOrganizationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        group.MapPost("/delete", [Topic(daprPubSubName, "FrmoDeleteOrganizationIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] DeleteOrganizationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return group;
    }
}
