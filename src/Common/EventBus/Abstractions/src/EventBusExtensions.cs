// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EventBus;

/// <summary>
/// Provides extension methods for the <see cref="IEventBus"/> interface.
/// </summary>
public static class EventBusExtensions
{
    /// <summary>
    /// Publishes an integration event.
    /// </summary>
    /// <typeparam name="TIntegrationEvent">The type of the event.</typeparam>
    /// <param name="eventBus">The event bus.</param>
    /// <param name="event">The event to publish.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task PublishAsync<TIntegrationEvent>(this IEventBus eventBus, TIntegrationEvent @event, CancellationToken cancellationToken = default)
        where TIntegrationEvent : IntegrationEvent
    {
        var topicName = @event.GetType().Name;
        await eventBus.PublishAsync(topicName, @event, cancellationToken);
    }
}