// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

public record HospitalSubdivision
{
    [XmlElement("oid")]
    [JsonPropertyName("oid")]
    public string Oid { get; init; } = default!;

    [XmlElement("subdivisionName")]
    [JsonPropertyName("subdivisionName")]
    public string SubdivisionName { get; init; } = default!;

    [XmlArray("healthCareProfile")]
    [XmlArrayItem("healthCareProfileItem")]
    [JsonPropertyName("healthCareProfile")]
    public HealthCareProfile[] HealthCareProfile { get; init; } = [];

    [XmlArray("services")]
    [XmlArrayItem("servicesItem")]
    [JsonPropertyName("services")]
    public Service[] Services { get; init; } = [];

    [XmlElement("subdivisionId")]
    [JsonPropertyName("subdivisionId")]
    public DepartmentSubdivision? SubdivisionId { get; init; }

    [XmlElement("liquidationDate")]
    [JsonPropertyName("liquidationDate")]
    public DateTime? LiquidationDate { get; init; }

    [XmlArray("buildings")]
    [XmlArrayItem("buildingsItem")]
    [JsonPropertyName("buildings")]
    public Building[]? Buildings { get; init; }

    [XmlArray("hospitalSubdivisionBeds")]
    [XmlArrayItem("hospitalSubdivisionBedsItem")]
    [JsonPropertyName("hospitalSubdivisionBeds")]
    public HospitalSubdivisionBed[]? HospitalSubdivisionBeds { get; init; }
}
