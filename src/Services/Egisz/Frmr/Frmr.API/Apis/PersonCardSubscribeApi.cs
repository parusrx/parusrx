// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmr.API;

public static class PersonCardSubscribeApi
{
    public static IEndpointRouteBuilder MapPersonCardSubscribeHandlers(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/", [Topic(daprPubSubName, "ListPersonCardIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, ListPersonCardIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/create", [Topic(daprPubSubName, "CreatePersonCardIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, CreatePersonCardIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/update", [Topic(daprPubSubName, "UpdatePersonCardIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, UpdatePersonCardIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/delete", [Topic(daprPubSubName, "DeletePersonCardIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, DeletePersonCardIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
