// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DaData.API.Integration;

/// <summary>
/// Defines methods for integration events with DaData.ru suggestions.
/// </summary>
public interface ISuggestPartyIntegrationEventService
{
    /// <summary>
    /// Retrieves the list of suggestions by parties to the specified party identifier.
    /// </summary>
    /// 
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The <see cref="Task"/> representing the asynchronous operation.</returns>
    Task FindPartyByIdAsync(MqIntegrationEvent @event, CancellationToken cancellationToken = default);
}
