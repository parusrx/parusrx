// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Routes;

public static class EducationCommonSubscribeApi
{
    public static IEndpointRouteBuilder MapEducationCommonSubscribeHandlers(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/", [Topic(daprPubSubName, "GetEducationCommonIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, GetEducationCommonIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/create", [Topic(daprPubSubName, "CreateEducationCommonIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, CreateEducationCommonIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/update", [Topic(daprPubSubName, "UpdateEducationCommonIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, UpdateEducationCommonIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/delete", [Topic(daprPubSubName, "DeleteEducationCommonIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, DeleteEducationCommonIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
