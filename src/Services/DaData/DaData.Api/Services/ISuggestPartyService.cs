// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DaData.Api.Services;

/// <summary>
/// Defines methods for the suggestion party service.
/// </summary>
public interface ISuggestPartyService
{
    /// <summary>
    /// Serialize the suggestion patry content to a byte array as an asynchronous operation.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    Task<byte[]> FindByIdAsync(DaDataSuggestPartyRequest request, CancellationToken cancellationToken = default);
}