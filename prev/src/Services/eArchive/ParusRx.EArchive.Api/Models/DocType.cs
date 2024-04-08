// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EArchive.Api.Models;

/// <summary>
/// Represents a document type.
/// </summary>
[XmlRoot(ElementName = "DocType")]
public class DocType
{
    /// <summary>
    /// Gets or sets the document name.
    /// </summary>
    [JsonPropertyName("name")]
    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the document code.
    /// </summary>
    [JsonPropertyName("code")]
    [XmlElement(ElementName = "Code")]
    public string Code { get; set; }
}
