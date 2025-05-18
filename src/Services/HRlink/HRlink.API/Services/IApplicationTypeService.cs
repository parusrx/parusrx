// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Services;

/// <summary>
/// Provides methods allowing to work with application types in the HRlink system.
/// </summary>
public interface IApplicationTypeService
{
    /// <summary>
    /// Gets the application types.
    /// </summary>
    /// <param name="request">The <see cref="ApplicationTypeRequest"/>.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The <see cref="ApplicationTypeResponse"/>.</returns>
    ValueTask<ApplicationTypeResponse?> GetApplicationTypesAsync(ApplicationTypeRequest request, CancellationToken cancellationToken = default);
}
