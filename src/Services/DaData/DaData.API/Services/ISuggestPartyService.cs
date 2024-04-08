// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

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
