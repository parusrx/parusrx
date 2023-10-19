// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
