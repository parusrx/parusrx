// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.API;

public static class PersonAccreditationSubscribeApi
{
    public static IEndpointRouteBuilder MapPersonAccreditationSubscribeHandlers(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/", [Topic(daprPubSubName, "GetPersonAccreditationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, GetPersonAccreditationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/create", [Topic(daprPubSubName, "CreatePersonAccreditationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, CreatePersonAccreditationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/update", [Topic(daprPubSubName, "UpdatePersonAccreditationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, UpdatePersonAccreditationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/delete", [Topic(daprPubSubName, "DeletePersonAccreditationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, DeletePersonAccreditationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
