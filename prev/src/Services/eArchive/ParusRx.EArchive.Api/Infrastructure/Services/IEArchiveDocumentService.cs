// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EArchive.Api.Services;

/// <summary>
/// Represents a service that provides methods for accessing to document on the BFT e-Archive.
/// </summary>
public interface IEArchiveDocumentService
{
    /// <summary>
    /// Retrieves document by internal identifier.
    /// </summary>
    /// <param name="id">The internal identifier.</param>
    /// <param name="accessToken">The access token.</param>
    /// <returns>Returns the document.</returns>
    /// <seealso cref="Document"/>
    Task<Document> ReadCardByIdAsync(string id, string accessToken);

    /// <summary>
    /// Retrieves document by external identifier and system code.
    /// </summary>
    /// <param name="systemCode">The system code.</param>
    /// <param name="externalId">The external identifier.</param>
    /// <param name="accessToken">The access token.</param>
    /// <returns>Returns the document.</returns>
    /// <seealso cref="Document"/>
    Task<Document> ReadCardAsync(string systemCode, string externalId, string accessToken);

    /// <summary>
    /// Retrieves attachment.
    /// </summary>
    /// <param name="id">The attachment identifier.</param>
    /// <param name="accessToken">The access token.</param>
    /// <returns>Returns attachments as string.</returns>
    Task<string> ReadAttachmentAsync(string id, string accessToken);

    /// <summary>
    /// Store document.
    /// </summary>
    /// <param name="document">The document body.</param>
    /// <param name="accessToken">The access token.</param>
    /// <returns>Returns the document.</returns>
    /// <seealso cref="Document"/>
    Task<Document> StoreAsync(StoreDocumentBody document, string accessToken);
}
