// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Infrastructure.Stores;

/// <summary>
/// Provides methods allowing to retrieve credentials stored in a database.
/// </summary>
public interface ICredentialsStore
{
    /// <summary>
    /// Gets all credentials.
    /// </summary>
    /// <returns>The credentials.</returns>
    /// <seealso cref="Credential"/>
    Task<IEnumerable<Credential>> GetAllCredentialsAsync();
}
