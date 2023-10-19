// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.API.Services;

/// <summary>
/// Provides methods allowing to work with documents in the HRlink system.
/// </summary>
public interface IDocumentService
{
    /// <summary>
    /// Creates a document group in the HRlink system.
    /// </summary>
    /// <param name="request">The <see cref="CreateDocumentGroupRequest"/>.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The <see cref="CreateDocumentGroupResponse"/>.</returns>
    ValueTask<CreateDocumentGroupResponse?> CreateDocumentGroupAsync(CreateDocumentGroupRequest request, CancellationToken cancellationToken = default);   
}
