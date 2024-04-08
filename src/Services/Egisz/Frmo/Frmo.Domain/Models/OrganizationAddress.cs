// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record OrganizationAddress
{
    [XmlElement("address")]
    [JsonPropertyName("address")]
    public Address Address { get; init; } = new();

    [XmlElement("addrRegion")]
    [JsonPropertyName("addrRegion")]
    public AddressRegion AddrRegion { get; init; } = new();

    [XmlElement("cadastralNumber")]
    [JsonPropertyName("cadastralNumber")]
    public string? CadasralNumber { get; init; }

    [XmlElement("latitude")]
    [JsonPropertyName("latitude")]
    public double? Latitude { get; init; }

    [XmlElement("longitude")]
    [JsonPropertyName("longitude")]
    public double? Longitude { get; init; }

    [XmlElement("postIndex")]
    [JsonPropertyName("postIndex")]
    public string? PostIndex { get; init; }
}
