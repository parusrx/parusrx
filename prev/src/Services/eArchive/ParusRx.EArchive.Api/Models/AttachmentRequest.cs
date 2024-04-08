// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EArchive.Api.Models;

/// <summary>
/// Represens an attachment request.
/// </summary>
[XmlRoot(ElementName = "AttachmentRequest")]
public class AttachmentRequest
{
    /// <summary>
    /// Gets or sets the credentials of the request.
    /// </summary>
    [XmlElement(ElementName = "Credential")]
    public Credential Credential { get; set; }

    /// <summary>
    /// Gets or sets the body of the attachment request.
    /// </summary>
    [XmlElement(ElementName = "AttachmentRequestBody")]
    public AttachmentRequestBody Attach { get; set; }
}
