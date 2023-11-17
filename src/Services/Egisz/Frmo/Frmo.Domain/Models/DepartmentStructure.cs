// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.Domain.Models;

public record DepartmentStructure
{
    [XmlElement("level")]
    [JsonPropertyName("level")]
    public string Level { get; init; } = default!;
    
    [XmlElement("headDepart")]
    [JsonPropertyName("headDepart")]
    public string HeadDepart { get; init; } = default!;
}
