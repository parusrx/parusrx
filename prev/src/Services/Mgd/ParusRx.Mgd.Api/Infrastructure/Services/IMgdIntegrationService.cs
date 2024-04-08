// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Infrastructure.Services;

/// <summary>
/// Represents a MGD integration service.
/// </summary>
public interface IMgdIntegrationService
{
    /// <summary>
    /// Gets a new message from MGD queue.
    /// </summary>
    /// <param name="credentials">The credentials.</param>
    /// <returns>
    /// The <see cref="MgdIntegrationResult"/>.
    /// </returns>
    /// <seealso cref="Credential"/>
    Task<MgdIntegrationResult> GetMessageAsync(Credential credentials);
}
