// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.API;

public static class EducationProfSubscribeApi
{
    public static IEndpointRouteBuilder MapEducationProfSubscribeHandlers(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/", [Topic(daprPubSubName, "ListEducationProfIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, GetEducationProfIntegrationEventHandler handler) =>
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
