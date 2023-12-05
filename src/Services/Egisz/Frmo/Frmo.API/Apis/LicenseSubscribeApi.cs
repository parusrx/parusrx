// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
