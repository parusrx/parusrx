// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.API;

public static class LicenseSubscribeApi
{
    public static IEndpointRouteBuilder MapLicenseSubscribeApi(this IEndpointRouteBuilder app) 
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/list", [Topic(daprPubSubName, "ListLicenseIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, ListLicenseIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/", [Topic(daprPubSubName, "GetLicenseIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, GetLicenseIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
