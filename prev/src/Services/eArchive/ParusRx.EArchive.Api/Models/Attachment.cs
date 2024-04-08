// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EArchive.Api.Models;

/// <summary>
/// Represents an attachment.
/// </summary>
[XmlRoot(ElementName = "Attach")]
public class Attachment
{
    /// <summary>
    /// Gets or sets the Id of the attachment.
    /// </summary>
    [JsonPropertyName("id")]
    [XmlElement(ElementName = "Id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the External Id of the attachment.
    /// </summary>
    [JsonPropertyName("extId")]
    [XmlElement(ElementName = "ExtId")]
    public string ExtId { get; set; }

    /// <summary>
    /// Gets or sests the file name of the attachment.
    /// </summary>
    [JsonPropertyName("fileName")]
    [XmlElement(ElementName = "FileName")]
    public string FileName { get; set; }

    /// <summary>
    /// Gets or sets the signatures of the attachment.
    /// </summary>
    [JsonPropertyName("signatures")]
    [XmlArray(ElementName = "Signatures")]
    [XmlArrayItem(ElementName = "Signature")]
    public List<AttachmentSignature> Signatures { get; set; } = new();
}
