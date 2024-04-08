// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record LocalityAddress
{
    [XmlElement("GARguid")]
    [JsonPropertyName("GARguid")]
    public string GarGuid { get; init; } = default!;

    [XmlElement("regionId")]
    [JsonPropertyName("regionId")]
    public int RegionId { get; init; }

    [XmlElement("localityLongitude")]
    [JsonPropertyName("localityLongitude")]
    public double LocalityLongitude { get; init; }

    [XmlElement("localityLatitude")]
    [JsonPropertyName("localityLatitude")]
    public double LocalityLatitude { get; init; }
}
