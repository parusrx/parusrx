// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmr.API;

public static class EducationProfSubscribeApi
{
    public static IEndpointRouteBuilder MapEducationProfSubscribeHandlers(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/", [Topic(daprPubSubName, "GetEducationProfIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, GetEducationProfIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/create", [Topic(daprPubSubName, "CreateEducationProfIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, CreateEducationProfIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/update", [Topic(daprPubSubName, "UpdateEducationProfIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, UpdateEducationProfIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/delete", [Topic(daprPubSubName, "DeleteEducationProfIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, DeleteEducationProfIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
