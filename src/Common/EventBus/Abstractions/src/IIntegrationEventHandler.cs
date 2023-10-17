// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EventBus;

/// <summary>
/// Provides an abstraction for handling integration events.
/// </summary>
/// <typeparam name="TIntegrationEvent">The type of the integration event.</typeparam>
public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
    where TIntegrationEvent : IntegrationEvent
{
    /// <summary>
    /// Handles an integration event.
    /// </summary>
    /// <param name="event">The integration event.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task HandleAsync(TIntegrationEvent @event, CancellationToken cancellationToken = default);
}

/// <summary>
/// Provides an abstraction for handling integration events.
/// </summary>
public interface IIntegrationEventHandler
{
}