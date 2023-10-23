// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

public record DepartmentAmbulatory
{
    [XmlElement("isCreatedOrReplacedPMSP")]
    [JsonPropertyName("isCreatedOrReplacedPMSP")]
    public bool IsCreatedOrReplacedPMSP { get; init; }

    [XmlElement("visitorsCount")]
    [JsonPropertyName("visitorsCount")]
    public int? VisitorsCount { get; init; }

    [XmlElement("isHomeVisit")]
    [JsonPropertyName("isHomeVisit")]
    public bool IsHomeVisit { get; init; }

    [XmlElement("isHomeVisitChild")]
    [JsonPropertyName("isHomeVisitChild")]
    public bool IsHomeVisitChild { get; init; }

    [XmlArray("room")]
    [XmlArrayItem("roomItem")]
    [JsonPropertyName("room")]
    public DepartmentRoom[]? Room { get; init; }
}
