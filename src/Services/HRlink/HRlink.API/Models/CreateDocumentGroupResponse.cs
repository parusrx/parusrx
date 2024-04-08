// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a create document group response.
/// </summary>
[XmlRoot("createDocumentGroupResponse")]
public record CreateDocumentGroupResponse
{
    /// <summary>
    /// Gets or sets the result of the create document group operation.
    /// </summary>
    [XmlElement("result")]
    [JsonPropertyName("result")]
    public required bool Result { get; init; }

    /// <summary>
    /// Gets or sets the document group.
    /// </summary>
    [XmlElement("documentGroup")]
    [JsonPropertyName("documentGroup")]
    public required DocumentGroupResultItem DocumentGroup { get; init; }
}
