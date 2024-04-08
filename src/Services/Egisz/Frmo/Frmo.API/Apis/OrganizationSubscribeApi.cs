// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.API;

internal static class OrganizationSubscribeApi
{
    public static IEndpointRouteBuilder MapOrganizationSubscribeApi(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/get-by-oid", [Topic(daprPubSubName, "FrmoGetByOidOrganizationIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] GetOrganizationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/list", [Topic(daprPubSubName, "FrmoListPagedOrganizationIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] ListPagedOrganizationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/update", [Topic(daprPubSubName, "FrmoUpdateOrganizationIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] UpdateOrganizationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/delete", [Topic(daprPubSubName, "FrmoDeleteOrganizationIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] DeleteOrganizationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
