// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Domain;

public record AirAmbulanceHelipadAddress
{
    [XmlElement("address")]
    [JsonPropertyName("address")]
    public Address Address { get; init; } = default!;

    [XmlElement("longitude")]
    [JsonPropertyName("longitude")]
    public double Longitude { get; init; }

    [XmlElement("latitude")]
    [JsonPropertyName("latitude")]
    public double Latitude { get; init; }
}
