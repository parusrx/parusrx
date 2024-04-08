// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.API;

public static class EducationOrganizationDepartSubscribeApi
{
    public static IEndpointRouteBuilder MapEducationOrganizationDepartSubscribeApi(this IEndpointRouteBuilder app)
    {
        const string daprPubSubName = "pubsub";

        app.MapPost("/list", [Topic(daprPubSubName, "ListEducationOrganizationDepartIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, ListEducationOrganizationDepartIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/", [Topic(daprPubSubName, "GetEducationOrganizationDepartIntegrationEvent")] async([FromBody] MqIntegrationEvent @event, GetEducationOrganizationDepartIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/create", [Topic(daprPubSubName, "CreateEducationOrganizationDepartIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, CreateEducationOrganizationDepartIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/update", [Topic(daprPubSubName, "UpdateEducationOrganizationDepartIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, UpdateEducationOrganizationDepartIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        app.MapPost("/delete", [Topic(daprPubSubName, "DeleteEducationOrganizationDepartIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, DeleteEducationOrganizationDepartIntegrationEventHandler handler) =>
        {
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
