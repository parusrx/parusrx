// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record DepartReg
{
    [XmlElement("isCreatedOrReplacedPMSP")]
    [JsonPropertyName("isCreatedOrReplacedPMSP")]
    public bool? IsCreatedOrReplacedPMSP { get; init; }

    [XmlElement("visitorsCount")]
    [JsonPropertyName("visitorsCount")]
    public int? VisitorsCount { get; init; }

    [XmlElement("isHomeVisit")]
    [JsonPropertyName("isHomeVisit")]
    public bool IsHomeVisit { get; init; }

    [XmlElement("isHomeVisitChild")]
    [JsonPropertyName("isHomeVisitChild")]
    public bool? IsHomeVisitChild { get; init; }

    [XmlArray("room")]
    [XmlArrayItem("roomItem")]
    [JsonPropertyName("room")]
    public DepartRegRoom[]? Room { get; init; }
}
