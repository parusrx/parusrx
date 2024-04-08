// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

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
