// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.Domain;

public record DepartmentLabaratory
{
    [XmlElement("labOid")]
    [JsonPropertyName("labOid")]
    public string LabOid { get; init; } = default!;

    [XmlArray("healthCareProfile")]
    [XmlArrayItem("healthCareProfileItem")]
    [JsonPropertyName("healthCareProfile")]
    public HealthCareProfile[] HealthCareProfile { get; init; } = [];

    [XmlArray("services")]
    [XmlArrayItem("servicesItem")]
    [JsonPropertyName("services")]
    public Service[] Services { get; init; } = [];

    [XmlElement("roomCount")]
    [JsonPropertyName("roomCount")]
    public int RoomCount { get; init; }

    [XmlElement("roomTypeId")]
    [JsonPropertyName("roomTypeId")]
    public RoomType RoomTypeId { get; init; } = default!;

    [XmlElement("examPerShift")]
    [JsonPropertyName("examPerShift")]
    public int? ExamPerShift { get; init; }

    [XmlArray("buildings")]
    [XmlArrayItem("buildingsItem")]
    [JsonPropertyName("buildings")]
    public Building[] Buildings { get; init; } = [];
}
