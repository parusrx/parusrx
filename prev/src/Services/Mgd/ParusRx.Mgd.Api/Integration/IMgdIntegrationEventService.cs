// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Integration;

/// <summary>
/// Provides abstraction methods for the MGD integration event service.
/// </summary>
public interface IMgdIntegrationEventService
{
    /// <summary>
    /// Retrieves the message.
    /// </summary>
    /// <param name="event">The <see cref="IntegrationEvent"/>.</param>
    /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
    Task GetMessageAsync(IntegrationEvent @event);
}
