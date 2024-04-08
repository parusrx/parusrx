// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EArchive.Api.Models;

/// <summary>
/// Represents a response to a stored document.
/// </summary>
[XmlRoot(ElementName = "StoreDocumentResponse")]
public class StoreDocumentResponse
{
    /// <summary>
    /// Gets or sets the document.
    /// </summary>
    [XmlElement("Document")]
    public Document Document { get; set; }
}
