// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EArchive.Api.Models;

/// <summary>
/// Represents an organization.
/// </summary>
[XmlRoot(ElementName = "Organisation")]
public class Organisation
{
    /// <summary>
    /// Gets or sets the name of the organization.
    /// </summary>
    [JsonPropertyName("name")]
    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the INN of the organization.
    /// </summary>
    [JsonPropertyName("inn")]
    [XmlElement(ElementName = "Inn")]
    public string Inn { get; set; }

    /// <summary>
    /// Gets or sets the OGRN of the organization.
    /// </summary>
    [JsonPropertyName("ogrn")]
    [XmlElement(ElementName = "Ogrn")]
    public string Ogrn { get; set; }

    /// <summary>
    /// Gets or sets the KPP of the organization.
    /// </summary>
    [JsonPropertyName("kpp")]
    [XmlElement(ElementName = "Kpp")]
    public string Kpp { get; set; }
}
