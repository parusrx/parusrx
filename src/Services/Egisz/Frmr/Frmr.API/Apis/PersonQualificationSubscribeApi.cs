// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmr.API;

public static class PersonQualificationSubscribeApi
{
    public static IEndpointRouteBuilder MapPersonQualificationSubscribeHandlers(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/", [Topic(daprPubSubName, "ListPersonQualificationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, ListPersonQualificationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/create", [Topic(daprPubSubName, "CreatePersonQualificationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, CreatePersonQualificationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/update", [Topic(daprPubSubName, "UpdatePersonQualificationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, UpdatePersonQualificationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/delete", [Topic(daprPubSubName, "DeletePersonQualificationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, DeletePersonQualificationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
