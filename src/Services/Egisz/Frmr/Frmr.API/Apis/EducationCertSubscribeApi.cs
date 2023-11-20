// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Routes;

public static class EducationCertSubscribeApi
{
    public static IEndpointRouteBuilder MapEducationCertSubscribeHandlers(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/", [Topic(daprPubSubName, "ListEducationCertIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, ListEducationCertIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/create", [Topic(daprPubSubName, "CreateEducationCertIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, CreateEducationCertIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/update", [Topic(daprPubSubName, "UpdateEducationCertIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, UpdateEducationCertIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/delete", [Topic(daprPubSubName, "DeleteEducationCertIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, DeleteEducationCertIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
