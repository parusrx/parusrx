// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DaData.Api.Services;

/// <summary>
/// Defines methods for suggesting parties.
/// </summary>
public interface ISuggestPartyService
{
    /// <summary>
    /// Serialize the suggestion party content to a byte array as an asynchronous operation.
    /// </summary>
    /// <param name="request">The <see cref="DaDataSuggestPartyRequest"/>.</param>
    /// <returns>The serialized value.</returns>
    Task<byte[]> FindByIdAsync(DaDataSuggestPartyRequest request);
}
