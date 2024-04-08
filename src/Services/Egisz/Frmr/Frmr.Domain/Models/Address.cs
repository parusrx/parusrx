// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.Domain;

public record Address
{
    [XmlElement("GARguid")]
    [JsonPropertyName("GARguid")]
    public string GarGuid { get; init; } = default!;

    [XmlElement("aoidArea")]
    [JsonPropertyName("aoidArea")]
    public string? AoidArea { get; init; }

    [XmlElement("aoidStreet")]
    [JsonPropertyName("aoidStreet")]
    public string? AoidStreet { get; init; }

    [XmlElement("houseid")]
    [JsonPropertyName("houseid")]
    public string? HouseId { get; init; }

    [XmlElement("region")]
    [JsonPropertyName("region")]
    public int Region { get; init; }

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
}
