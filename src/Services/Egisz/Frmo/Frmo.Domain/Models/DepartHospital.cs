// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Domain;

public record DepartHospital
{
    [XmlElement("hospitalModelId")]
    [JsonPropertyName("hospitalModelId")]
    public HospitalModelId? HospitalModelId { get; init; }

    [XmlElement("ambulance")]
    [JsonPropertyName("ambulance")]
    public bool? Ambulance { get; init; }

    [XmlElement("homeBedCount")]
    [JsonPropertyName("homeBedCount")]
    public int? HomeBedCount { get; init; }

    [XmlElement("homeBuildingName")]
    [JsonPropertyName("homeBuildingName")]
    public string? HomeBuildingName { get; init; }

    [XmlArray("hospitalSubdivision")]
    [XmlArrayItem("hospitalSubdivisionItem")]
    [JsonPropertyName("hospitalSubdivision")]
    public HospitalSubdivision[]? HospitalSubdivision { get; init; }
}
