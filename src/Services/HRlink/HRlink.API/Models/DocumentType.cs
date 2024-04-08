// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a document type.
/// </summary>
[XmlRoot("documentType")]
public record DocumentType
{
    /// <summary>
    /// Gets or sets the identifier of the document type.
    /// </summary>
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets or sets the name of the document type.
    /// </summary>
    [XmlElement("name")]
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Gets or sets the visible of the document type.
    /// </summary>
    [XmlElement("visible")]
    [JsonPropertyName("visible")]
    public bool Visible { get; init; }

    /// <summary>
    /// Gets or sets the system of the document type.
    /// </summary>
    [XmlElement("system")]
    [JsonPropertyName("system")]
    public bool System { get; init; }

    /// <summary>
    /// Gets or sets the external identifier of the document type.
    /// </summary>
    [XmlElement("externalId")]
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; init; }

    /// <summary>
    /// Gets or sets the version of the document type.
    /// </summary>
    [XmlElement("version")]
    [JsonPropertyName("version")]
    public int Version { get; init; }
}
