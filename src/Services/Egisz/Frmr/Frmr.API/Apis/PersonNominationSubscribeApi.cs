// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.API;

public static class PersonNominationSubscribeApi
{
    public static IEndpointRouteBuilder MapPersonNominationSubscribeHandlers(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/", [Topic(daprPubSubName, "ListPersonNominationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, ListPersonNominationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/create", [Topic(daprPubSubName, "CreatePersonNominationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, CreatePersonNominationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/update", [Topic(daprPubSubName, "UpdatePersonNominationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, UpdatePersonNominationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/delete", [Topic(daprPubSubName, "DeletePersonNominationIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, DeletePersonNominationIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
