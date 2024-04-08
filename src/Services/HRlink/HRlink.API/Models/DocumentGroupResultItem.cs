// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a document group result item for a create document group response.
/// </summary>
public record DocumentGroupResultItem
{
    /// <summary>
    /// Gets or sets the identifier of the document group.
    /// </summary>
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets or sets the documents included in the document group.
    /// </summary>
    [XmlArray("documents")]
    [XmlArrayItem("document")]
    [JsonPropertyName("documents")]
    public DocumentResultItem[]? Documents { get; init; }
}
