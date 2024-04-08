// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.API;

public static class EducationPostgraduateSubscribeApi
{
    public static IEndpointRouteBuilder MapEducationPostgraduateSubscribeHandlers(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/", [Topic(daprPubSubName, "ListEducationPostgraduateIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, ListEducationPostgraduateIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/create", [Topic(daprPubSubName, "CreateEducationPostgraduateIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, CreateEducationPostgraduateIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/update", [Topic(daprPubSubName, "UpdateEducationPostgraduateIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, UpdateEducationPostgraduateIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/delete", [Topic(daprPubSubName, "DeleteEducationPostgraduateIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, DeleteEducationPostgraduateIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
