// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EventBus.Abstractions;

/// <summary>
/// Provides abstractions for publishing an integration event to the service bus.
/// </summary>
public interface IEventBus
{
    /// <summary>
    /// Publishes the provided <paramref name="event"/>.
    /// </summary>
    /// <typeparam name="TIntegrationEvent">The type of the integration event.</typeparam>
    /// <param name="topicName">The topic name.</param>
    /// <param name="event">Integration event.</param>
    /// <returns>A <see cref="Task"/> which will complete when publishing is complete.</returns>
    Task PublishAsync<TIntegrationEvent>(string topicName, TIntegrationEvent @event)
        where TIntegrationEvent : IntegrationEvent;
}
