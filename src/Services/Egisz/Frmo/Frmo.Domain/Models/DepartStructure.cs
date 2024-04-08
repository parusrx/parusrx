// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

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
