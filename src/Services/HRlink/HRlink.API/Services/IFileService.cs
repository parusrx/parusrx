// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.API.Services;

/// <summary>
/// Provides methods allowing to work with files in HRlink.
/// </summary>
public interface IFileService
{
    /// <summary>
    /// Uploads files to HRlink.
    /// </summary>
    /// <param name="request">The <see cref="FilesUploadRequest"/>.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The <see cref="FilesUploadResponse"/>.</returns>
    ValueTask<FilesUploadResponse?> UploadAsync(FilesUploadRequest request, CancellationToken cancellationToken = default);
}
