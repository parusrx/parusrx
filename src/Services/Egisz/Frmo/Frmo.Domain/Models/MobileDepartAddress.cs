// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Domain;

public record MobileDepartAddress
{
    [XmlElement("mobileDepartAddressId")]
    [JsonPropertyName("mobileDepartAddressId")]
    public string? MobileDepartAddressId { get; set; }

    [XmlElement("GARguid")]
    [JsonPropertyName("GARguid")]
    public string GarGuid { get; set; } = default!;

    [XmlElement("regionId")]
    [JsonPropertyName("regionId")]
    public int RegionId { get; set; }

    [XmlElement("latitude")]
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [XmlElement("longitude")]
    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }
}
