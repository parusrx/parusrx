// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a document group request item for a create document group request.
/// </summary>
[XmlRoot("documentGroup")]
public record DocumentGroupRequestItem
{
    /// <summary>
    /// Gets or sets the name of the document group.
    /// </summary>
    [XmlElement("name")]
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// Gets or sets the external identifier of the creator of the document group.
    /// </summary>
    [XmlElement("creatorExternalId")]
    [JsonPropertyName("creatorExternalId")]
    public required string CreatorExternalId { get; init; }

    /// <summary>
    /// Gets or sets the documents of the document group.
    /// </summary>
    [XmlArray("documents")]
    [XmlArrayItem("document")]
    [JsonPropertyName("documents")]
    public required DocumentRequestItem[] Documents { get; init; } = [];
}
