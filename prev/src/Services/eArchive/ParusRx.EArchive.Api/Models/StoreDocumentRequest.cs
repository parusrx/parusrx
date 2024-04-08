// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EArchive.Api.Models;

/// <summary>
/// Represents a request to store a document.
/// </summary>
[XmlRoot(ElementName = "StoreDocumentRequest")]
public class StoreDocumentRequest
{
    /// <summary>
    /// Gets or sets the credentials.
    /// </summary>
    [XmlElement(ElementName = "Credential")]
    public Credential Credential { get; set; }

    /// <summary>
    /// Gets or sets the body of the request.
    /// </summary>
    [XmlElement(ElementName = "StoreDocumentBody")]
    public StoreDocumentBody StoreDocumentBody { get; set; }
}
