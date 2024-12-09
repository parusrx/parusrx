// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Services;

/// <summary>
/// Represents an auto-updater document.
/// </summary>
public interface IAutoUpdateDocumentStatusService
{
    /// <summary>
    /// Executes the auto-updater.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The <see cref="Task"/>.</returns>
    Task ExecuteAsync(CancellationToken cancellationToken = default);
}
