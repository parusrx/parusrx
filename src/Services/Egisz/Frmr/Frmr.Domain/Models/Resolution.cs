// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.Domain;

[XmlRoot("resolution")]
public record Resolution
{
    [XmlElement("resolutionSpec")]
    [JsonPropertyName("resolutionSpec")]
    public ResolutionSpec? ResolutionSpec { get; init; }

    [XmlElement("resolutionMpSpec")]
    [JsonPropertyName("resolutionMpSpec")]
    public ResolutionMpSpec? ResolutionMpSpec { get; init; }

    [XmlElement("resolutionDate")]
    [JsonPropertyName("resolutionDate")]
    public DateTime? ResolutionDate { get; init; }

    [XmlElement("resolutionNumber")]
    [JsonPropertyName("resolutionNumber")]
    public string? ResolutionNumber { get; init; }
}
