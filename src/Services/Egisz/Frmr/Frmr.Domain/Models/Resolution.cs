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

public record ResolutionSpec
{
    [XmlElement("code")]
    [JsonPropertyName("code")]
    public int? Code { get; init; }

    [XmlElement("name")]
    [JsonPropertyName("name")]
    public string? Name { get; init; }
}

public record ResolutionMpSpec
{
    [XmlElement("code")]
    [JsonPropertyName("code")]
    public int? Code { get; init; }

    [XmlElement("name")]
    [JsonPropertyName("name")]
    public string? Name { get; init; }
}