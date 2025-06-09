// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record Address
{
    [XmlElement("aoidArea")]
    [JsonPropertyName("aoidArea")]
    public string? AOidArea { get; init; }

    [XmlElement("aoidStreet")]
    [JsonPropertyName("aoidStreet")]
    public string? AOidStreet { get; init; }

    [XmlElement("houseid")]
    [JsonPropertyName("houseid")]
    public string? HouseId { get; init; }

    [XmlElement("houseguid")]
    [JsonPropertyName("houseguid")]
    public string? HouseGuid { get; init; }

    [XmlElement("GARguid")]
    [JsonPropertyName("GARguid")]
    public string GarGuid { get; init; } = default!;

    [XmlElement("region")]
    [JsonPropertyName("region")]
    public Region Region { get; init; } = default!;

    [XmlElement("areaName")]
    [JsonPropertyName("areaName")]
    public string? AreaName { get; init; }

    [XmlElement("prefixArea")]
    [JsonPropertyName("prefixArea")]
    public string? PrefixArea { get; init; }

    [XmlElement("streetName")]
    [JsonPropertyName("streetName")]
    public string? StreetName { get; init; }

    [XmlElement("prefixStreet")]
    [JsonPropertyName("prefixStreet")]
    public string? PrefixStreet { get; init; }

    [XmlElement("house")]
    [JsonPropertyName("house")]
    public string? House { get; init; }

    [XmlElement("building")]
    [JsonPropertyName("building")]
    public string? Building { get; init; }

    [XmlElement("struct")]
    [JsonPropertyName("struct")]
    public string? Struct { get; init; }

    [XmlElement("flat")]
    [JsonPropertyName("flat")]
    public string? Flat { get; init; }

    [XmlElement("apartmentId")]
    [JsonPropertyName("apartmentId")]
    public string? ApartmentId { get; init; }

    [XmlElement("apartment")]
    [JsonPropertyName("apartment")]
    public string? Apartment { get; init; }

    [XmlElement("prefixApartment")]
    [JsonPropertyName("prefixApartment")]
    public string? PrefixApartment { get; init; }

    [XmlElement("steadId")]
    [JsonPropertyName("steadId")]
    public string? SteadId { get; init; }

    [XmlElement("stead")]
    [JsonPropertyName("stead")]
    public string? Stead { get; init; }

    [XmlElement("prefixStead")]
    [JsonPropertyName("prefixStead")]
    public string? PrefixStead { get; init; }

    [XmlElement("microdistrictId")]
    [JsonPropertyName("microdistrictId")]
    public string? MicrodistrictId { get; init; }

    [XmlElement("microdistrict")]
    [JsonPropertyName("microdistrict")]
    public string? Microdistrict { get; init; }

    [XmlElement("prefixmicrodistrict")]
    [JsonPropertyName("prefixmicrodistrict")]
    public string? PrefixMicrodistrict { get; init; }
}
