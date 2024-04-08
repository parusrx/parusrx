// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record Land
{
    [XmlElement("landId")]
    [JsonPropertyName("landId")]
    public string? LandId { get; init; }

    [XmlElement("landName")]
    [JsonPropertyName("landName")]
    public string? LandName { get; init; }

    [XmlElement("landArea")]
    [JsonPropertyName("landArea")]
    public double? LandArea { get; init; }
}
