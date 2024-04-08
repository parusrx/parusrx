// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Infrastructure.Services;

/// <summary>
/// Interface for the identity service.
/// </summary>
public interface IIdentityService
{
    /// <summary>
    /// Retrieves user token.
    /// </summary>
    /// <param name="userName">The username.</param>
    /// <param name="password">The password.</param>
    /// <returns>An <see cref="UserToken"/>.</returns>
    Task<UserToken> GetTokenAsync(string userName, string password);
}
