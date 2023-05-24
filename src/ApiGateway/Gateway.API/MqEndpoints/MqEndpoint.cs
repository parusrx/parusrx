// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Gateway.API.MqEndpoints;

/// <summary>
/// Publishes a message to the message queue.
/// </summary>
internal static class MqEndpoint
{
    /// <summary>
    /// Maps the endpoint.
    /// </summary>
    /// <param name="routes">The routes.</param>
    /// <returns>The endpoint convention builder.</returns>
    internal static IEndpointConventionBuilder MapMq(this IEndpointRouteBuilder routes)
    {
        return routes.MapPost("api/v1/mq", PublishMessage);
    }

    /// <summary>
    /// Publishes the message.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="eventBus">The event bus.</param>
    /// <returns>The result.</returns>
    internal static async Task<IResult> PublishMessage(Message message, IEventBus eventBus)
    {
        if (message is null)
        {
            return TypedResults.BadRequest();
        }

        var @event = new IntegrationEvent { Payload = message.Payload };
        await eventBus.PublishAsync(message.Topic, @event);
        return TypedResults.Created();
    }
}