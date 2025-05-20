// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.API;

internal static class OrganizationOmsSubscribeApi
{
    public static IEndpointRouteBuilder MapOrganizationOmsSubscribeApi(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";
        app.MapPost("/", [Topic(daprPubSubName, "FrmoGetOrganizationOmsIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] GetOrganizationOmsIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });
        app.MapPost("/list", [Topic(daprPubSubName, "FrmoListPagedOrganizationOmsIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] ListPagedOrganizationOmsIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });
        app.MapPost("/update", [Topic(daprPubSubName, "FrmoUpdateOrganizationOmsIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] UpdateOrganizationOmsIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });
        return app;
    }
}
