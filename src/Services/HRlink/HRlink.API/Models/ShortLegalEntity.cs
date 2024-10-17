// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a short legal entity.
/// </summary>
[XmlRoot("legalEntity")]
public record ShortLegalEntity
{
    /// <summary>
    /// Gets or sets the name of the legal entity.
    /// </summary>
    [XmlElement("name")]
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// Gets or sets the short name of the legal entity.
    /// </summary>
    [XmlElement("shortName")]
    [JsonPropertyName("shortName")]
    public required string ShortName { get; init; }

    /// <summary>
    /// Gets or sets the external identifier of the legal entity.
    /// </summary>
    [XmlElement("externalId")]
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; init; }

    /// <summary>
    /// Gets or sets the identifier of the legal entity.
    /// </summary>
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }
}
