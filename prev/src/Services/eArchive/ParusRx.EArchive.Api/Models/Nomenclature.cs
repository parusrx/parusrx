// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EArchive.Api.Models;

/// <summary>
/// Represents a nomenclature.
/// </summary>
[XmlRoot(ElementName = "Nomenclature")]
public class Nomenclature
{
    /// <summary>
    /// Gets or sets the name of the nomenclature.
    /// </summary>
    [JsonPropertyName("name")]
    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the code of the nomenclature.
    /// </summary>
    [JsonPropertyName("code")]
    [XmlElement(ElementName = "Code")]
    public string Code { get; set; }
}
