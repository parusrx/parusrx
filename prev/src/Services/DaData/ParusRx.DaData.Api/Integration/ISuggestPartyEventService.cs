// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DaData.Api.Integration;

/// <summary>
/// Defines methods for integration events with DaData.ru suggestions.
/// </summary>
public interface ISuggestPartyEventService
{
    /// <summary>
    /// Retrieves the list of suggestions by parties to the specified party identifier.
    /// </summary>
    /// <param name="event">The <see cref="IntegrationEvent"/>.</param>
    /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
    Task FindPartyByIdAsync(IntegrationEvent @event);
}
