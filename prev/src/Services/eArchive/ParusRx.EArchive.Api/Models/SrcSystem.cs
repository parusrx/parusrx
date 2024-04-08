// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EArchive.Api.Models;

/// <summary>
/// Represents the source system.
/// </summary>
[XmlRoot(ElementName = "SrcSystem")]
public class SrcSystem
{
    /// <summary>
    /// Gets or sets the name of the source system.
    /// </summary>
    [JsonPropertyName("name")]
    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the code of the source system.
    /// </summary>
    [JsonPropertyName("code")]
    [XmlElement(ElementName = "Code")]
    public string Code { get; set; }
}
