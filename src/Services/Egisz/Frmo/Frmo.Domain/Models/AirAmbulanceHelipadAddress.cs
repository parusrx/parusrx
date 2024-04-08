// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

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
