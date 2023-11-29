// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Domain;

public record AirAmbulanceDepart
{
    [XmlElement("code")]
    [JsonPropertyName("code")]
    public string Code { get; init; } = default!;

    [XmlElement("name")]
    [JsonPropertyName("name")]
    public string? Name { get; init; }
}
