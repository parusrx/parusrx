// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record HospitalSubdivision
{
    [XmlElement("oid")]
    [JsonPropertyName("oid")]
    public string Oid { get; init; } = default!;

    [XmlElement("subdivisionName")]
    [JsonPropertyName("subdivisionName")]
    public string? SubdivisionName { get; init; }

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
    public SubdivisionId? SubdivisionId { get; init; }

    [XmlElement("liquidationDate")]
    [JsonPropertyName("liquidationDate")]
    public DateTime? LiquidationDate { get; init; }

    [XmlArray("buildings")]
    [XmlArrayItem("buildingsItem")]
    [JsonPropertyName("buildings")]
    public Building[]? Buildings { get; init; }

    [XmlArray("category")]
    [XmlArrayItem("categoryItem")]
    [JsonPropertyName("category")]
    public Category[]? Category { get; init; }

    [XmlElement("healthCareConditions")]
    [JsonPropertyName("healthCareConditions")]
    public HealthCareCondition? HealthCareConditions { get; init; }

    [XmlArray("hospitalSubdivisionBeds")]
    [XmlArrayItem("hospitalSubdivisionBedsItem")]
    [JsonPropertyName("hospitalSubdivisionBeds")]
    public HospitalSubdivisionBed[]? HospitalSubdivisionBeds { get; init; }
}
