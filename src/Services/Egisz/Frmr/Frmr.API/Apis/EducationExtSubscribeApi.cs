// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.API;

public static class EducationExtSubscribeApi
{
    public static IEndpointRouteBuilder MapEducationExtSubscribeHandlers(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/", [Topic(daprPubSubName, "ListEducationExtIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, ListEducationExtIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/create", [Topic(daprPubSubName, "CreateEducationExtIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, CreateEducationExtIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/update", [Topic(daprPubSubName, "UpdateEducationExtIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, UpdateEducationExtIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/delete", [Topic(daprPubSubName, "DeleteEducationExtIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, DeleteEducationExtIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
