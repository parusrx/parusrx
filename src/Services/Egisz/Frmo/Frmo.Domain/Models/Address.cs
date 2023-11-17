// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.Domain.Models;

public record Address
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public int Id { get; init; } = default!;

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
    public string? Structure { get; init; }

    [XmlElement("flat")]
    [JsonPropertyName("flat")]
    public string? Flat { get; init; }
}
