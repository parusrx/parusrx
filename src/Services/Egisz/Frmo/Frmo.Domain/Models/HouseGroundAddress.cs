// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record HouseGroundAddress
{
    [XmlElement("houseGroundAddressId")]
    [JsonPropertyName("houseGroundAddressId")]
    public string? HouseGroundAddressId { get; init; }

    [XmlElement("postIndex")]
    [JsonPropertyName("postIndex")]
    public string? PostIndex { get; init; }

    [XmlElement("address")]
    [JsonPropertyName("address")]
    public Address Address { get; init; } = default!;

    [XmlElement("cadastralNumber")]
    [JsonPropertyName("cadastralNumber")]
    public string? CadastralNumber { get; init; }

    [XmlElement("latitude")]
    [JsonPropertyName("latitude")]
    public double Latitude { get; init; }

    [XmlElement("longitude")]
    [JsonPropertyName("longitude")]
    public double Longitude { get; init; }
}
