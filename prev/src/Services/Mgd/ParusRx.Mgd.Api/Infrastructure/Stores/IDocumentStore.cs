// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Infrastructure.Stores;

/// <summary>
/// Provides methods allowing to manage a document stored in a database.
/// </summary>
public interface IDocumentStore
{
    /// <summary>
    /// Uploads document.
    /// </summary>
    /// <param name="companyId">The company identifier.</param>
    /// <param name="juridicalPersonId">The juridical person identifier.</param>
    /// <param name="message">The message.</param>
    /// <returns>The <see cref="Task"/> that represents the asynchronous handle operation.</returns>
    Task UploadDocumentAsync(long companyId, long juridicalPersonId, Message message);
}
