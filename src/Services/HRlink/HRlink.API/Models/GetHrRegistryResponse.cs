// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a get HR registry response.
/// </summary>
[XmlRoot("getHrRegistryResponse")]
public record GetHrRegistryResponse
{
    /// <summary>
    /// Gets or sets the result of the create document group operation.
    /// </summary>
    [XmlElement("result")]
    [JsonPropertyName("result")]
    public required bool Result { get; init; }

    /// <summary>
    /// Gets or sets the document groups.
    /// </summary>
    [XmlArray("documentGroups")]
    [XmlArrayItem("documentGroup")]
    [JsonPropertyName("documentGroups")]
    public required DocumentGroupRegistry[] DocumentGroups { get; init; } = [];
}
