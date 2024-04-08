// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EventBus.Abstractions;

/// <summary>
/// Provides an abstraction for an integration event handler.
/// </summary>
public interface IIntegrationEventHandler
{
    /// <summary>
    /// Handle the integration event.
    /// </summary>
    /// <param name="event">The integration event.</param>
    /// <returns>The <see cref="Task"/> that represents the asynchronous handle operation.</returns>
    Task HandleAsync(IntegrationEvent @event);
}
