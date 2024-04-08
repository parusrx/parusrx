// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a file item.
/// </summary>
[XmlRoot("file")]
public record FileItem
{
    /// <summary>
    /// Gets or sets the identifier of the file.
    /// </summary>
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// Gets or sets the name of the file.
    /// </summary>
    [XmlElement("name")]
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// Gets or sets the created date of the file.
    /// </summary>
    [XmlElement("createdDate")]
    [JsonPropertyName("createdDate")]
    public required DateTime CreatedDate { get; init; }
}
