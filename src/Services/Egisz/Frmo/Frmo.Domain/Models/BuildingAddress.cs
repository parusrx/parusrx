// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Domain;

public record BuildingAddress
{
    [XmlElement("addrRegion")]
    [JsonPropertyName("addrRegion")]
    public string AddrRegion { get; init; } = default!;

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
