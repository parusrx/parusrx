// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EventBus.Extensions;

/// <summary>
/// Contains extensions for <see cref="IEventBus"/>.
/// </summary>
public static class EventBusExtensions
{
    /// <summary>
    /// Publishes the provided <paramref name="event"/>.
    /// </summary>
    /// <typeparam name="TIntegrationEvent">The type of the integration event.</typeparam>
    /// <param name="eventBus">The <see cref="IEventBus"/>.</param>
    /// <param name="event">Integration event.</param>
    /// <returns>A <see cref="Task"/> which will complete when publishing is complete.</returns>
    public static async Task PublishAsync<TIntegrationEvent>(this IEventBus eventBus, TIntegrationEvent @event)
        where TIntegrationEvent : IntegrationEvent
    {
        var topicName = @event.GetType().Name;

        await eventBus.PublishAsync(topicName, @event);
    }
}
