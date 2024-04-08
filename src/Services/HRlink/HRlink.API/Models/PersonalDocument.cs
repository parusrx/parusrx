// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a personal document.
/// </summary>
[XmlRoot("personalDocument")]
public record PersonalDocument
{
    /// <summary>
    /// Gets or sets the type of the personal document.
    /// </summary>
    [XmlElement("type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    [JsonPropertyName("type")]
    public PersonalDocumentType? Type { get; init; }

    /// <summary>
    /// Gets or sets the number of the personal document.
    /// </summary>
    [XmlElement("number")]
    [JsonPropertyName("number")]
    public string? Number { get; init; }

    /// <summary>
    /// Gets or sets the series of the personal document.
    /// </summary>
    [XmlElement("serialNumber")]
    [JsonPropertyName("serialNumber")]
    public string? SerialNumber { get; init; }

    /// <summary>
    /// Gets or sets the citizenship.
    /// </summary>
    [XmlElement("citizenship")]
    [JsonPropertyName("citizenship")]
    public string? Citizenship { get; init; }

    /// <summary>
    /// Gets or sets the issued date of the personal document.
    /// </summary>
    [XmlElement("issuedDate")]
    [JsonPropertyName("issuedDate")]
    public DateTime? IssuedDate { get; init; }

    /// <summary>
    /// Gets or sets the issuing authority code.
    /// </summary>
    [XmlElement("issuingAuthorityCode")]
    [JsonPropertyName("issuingAuthorityCode")]
    public string? IssuingAuthorityCode { get; init; }

    /// <summary>
    /// Gets or sets the issuing authority.
    /// </summary>
    [XmlElement("issuingAuthority")]
    [JsonPropertyName("issuingAuthority")]
    public string? IssuingAuthority { get; init; }

    /// <summary>
    /// Gets or sets the birth place.
    /// </summary>
    [XmlElement("birthPlace")]
    [JsonPropertyName("birthplace")]
    public string? BirthPlace { get; init; }
}

/// <summary>
/// Represents a personal document type.
/// </summary>
public enum PersonalDocumentType
{
    /// <summary>
    /// The passport.
    /// </summary>
    [XmlEnum("PASSPORT")]
    PASSPORT,

    /// <summary>
    /// The SNILS.
    /// </summary>
    [XmlEnum("SNILS")]
    SNILS,

    /// <summary>
    /// The INN.
    /// </summary>
    [XmlEnum("INN")]
    INN
}
