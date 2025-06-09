// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record DepartRegRoom
{
    [XmlElement("oid")]
    [JsonPropertyName("oid")]
    public string Oid { get; init; } = default!;

    [XmlArray("healthCareProfile")]
    [XmlArrayItem("healthCareProfileItem")]
    [JsonPropertyName("healthCareProfile")]
    public HealthCareProfile[]? HealthCareProfile { get; init; }

    [XmlArray("services")]
    [XmlArrayItem("servicesItem")]
    [JsonPropertyName("services")]
    public Service[] Services { get; init; } = [];

    [XmlElement("subdivisionId")]
    public SubdivisionId SubdivisionId { get; init; } = default!;

    [XmlArray("buildings")]
    [XmlArrayItem("buildingsItem")]
    [JsonPropertyName("buildings")]
    public Building[] Buildings { get; init; } = [];

    [XmlArray("category")]
    [XmlArrayItem("categoryItem")]
    [JsonPropertyName("category")]
    public Category[]? Category { get; init; }

    [XmlElement("healthCareConditions")]
    [JsonPropertyName("healthCareConditions")]
    public HealthCareCondition? HealthCareConditions { get; init; } = default!;
}
