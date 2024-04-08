// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EArchive.Api.Models;

/// <summary>
/// Represents an attachment signature.
/// </summary>
[XmlRoot(ElementName = "AttachmentSignature")]
public class AttachmentSignature
{
    /// <summary>
    /// Gets ot sets the identifier of the attachment signature.
    /// </summary>
    [JsonPropertyName("id")]
    [XmlElement(ElementName = "Id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the external identifier of the attachment signature.
    /// </summary>
    [JsonPropertyName("extId")]
    [XmlElement(ElementName = "ExtId")]
    public string ExtId { get; set; }

    /// <summary>
    /// Gets or sets the file name of the attachment request.
    /// </summary>
    [JsonPropertyName("fileName")]
    [XmlElement(ElementName = "FileName")]
    public string FileName { get; set; }
}
