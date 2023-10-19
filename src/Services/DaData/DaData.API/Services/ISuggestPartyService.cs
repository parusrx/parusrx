// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DaData.API.Services;

/// <summary>
/// Defines methods for the suggestion party service.
/// </summary>
public interface ISuggestPartyService
{
    /// <summary>
    /// Serialize the suggestion party content to a byte array as an asynchronous operation.
    /// </summary>
    /// <param name="suggestionsRequest">The suggestion request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    Task<byte[]> FindByIdAsync(DaDataSuggestPartyRequest suggestionsRequest, CancellationToken cancellationToken = default);
}
