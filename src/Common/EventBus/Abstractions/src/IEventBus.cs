// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EventBus;

/// <summary>
/// Provides an abstraction for publishing integration events.
/// </summary>
public interface IEventBus
{
    /// <summary>
    /// Publishes an integration event.
    /// </summary>
    /// <typeparam name="TIntegrationEvent">The type of the integration event.</typeparam>
    /// <param name="topicName">The name of the topic.</param>
    /// <param name="event">The integration event.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task PublishAsync<TIntegrationEvent>(string topicName, TIntegrationEvent @event, CancellationToken cancellationToken = default)
        where TIntegrationEvent : IntegrationEvent;
}