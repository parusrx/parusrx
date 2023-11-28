// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Domain;

public record DepartStructure
{
    [XmlElement("level")]
    [JsonPropertyName("level")]
    public string Level { get; init; } = default!;
    
    [XmlElement("headDepart")]
    [JsonPropertyName("headDepart")]
    public string HeadDepart { get; init; } = default!;
}
