// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.API;

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
