// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a legal entity.
/// </summary>
[XmlRoot("legalEntity")]
public record LegalEntity
{
    /// <summary>
    /// Gets or sets the identifier of the legal entity.
    /// </summary>
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets or sets the name of the legal entity.
    /// </summary>
    [XmlElement("name")]
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Gets or sets the short name of the legal entity.
    /// </summary>
    [XmlElement("shortName")]
    [JsonPropertyName("shortName")]
    public string? ShortName { get; init; }

    /// <summary>
    /// Gets or sets the OGRN of the legal entity.
    /// </summary>
    [XmlElement("ogrn")]
    [JsonPropertyName("ogrn")]
    public string? Ogrn { get; init; }

    /// <summary>
    /// Gets or sets the INN of the legal entity.
    /// </summary>
    [XmlElement("inn")]
    [JsonPropertyName("inn")]
    public string? Inn { get; init; }

    /// <summary>
    /// Gets or sets the KPP of the legal entity.
    /// </summary>
    [XmlElement("kpp")]
    [JsonPropertyName("kpp")]
    public string? Kpp { get; init; }

    /// <summary>
    /// Gets or sets the external identifier of the legal entity.
    /// </summary>
    [XmlElement("externalId")]
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; init; }
}
