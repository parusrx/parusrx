// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.Domain;

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
