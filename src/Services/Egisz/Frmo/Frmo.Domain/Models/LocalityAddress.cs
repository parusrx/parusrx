// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
