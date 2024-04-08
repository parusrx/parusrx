// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EArchive.Api.Models;

/// <summary>
/// Represents an attachment request body.
/// </summary>
[XmlRoot(ElementName = "AttachmentRequestBody")]
public class AttachmentRequestBody
{
    /// <summary>
    /// Gets or sets the identifier of the file.
    /// </summary>
    [XmlElement(ElementName = "FileUUID")]
    public string Id { get; set; }
}
