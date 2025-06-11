// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a role in the Docflow system.
/// </summary>
public record DocflowSystemRole
{
    /// <summary>
    /// Gets or sets the identifier of the role.
    /// </summary>
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets or sets the key of the role.
    /// </summary>
    [XmlElement("key")]
    [JsonPropertyName("key")]
    public string? Key { get; init; }

    ///// <summary>
    ///// Gets or sets the name of the role.
    ///// </summary>
    //[XmlElement("name")]
    //[JsonPropertyName("name")]
    //public I18nMessage? Name { get; init; }
}
