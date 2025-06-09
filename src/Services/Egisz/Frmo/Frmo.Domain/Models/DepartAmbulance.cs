// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record DepartAmbulance
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [XmlElement("brigadeId")]
    [JsonPropertyName("brigadeId")]
    public string? BrigadeId { get; init; }

    [XmlElement("brigadeCount")]
    [JsonPropertyName("brigadeCount")]
    public int BrigadeCount { get; init; }

    [XmlElement("brigadeCountSingle")]
    [JsonPropertyName("brigadeCountSingle")]
    public int BrigadeCountSingle { get; init; }

    [XmlElement("carCount")]
    [JsonPropertyName("carCount")]
    public int? CarCount { get; init; }

    [XmlElement("departurePerShift")]
    [JsonPropertyName("departurePerShift")]
    public int? DeparturePerShift { get; init; }

    [XmlElement("departurePerShiftOms")]
    [JsonPropertyName("departurePerShiftOms")]
    public int? DeparturePerShiftOms { get; init; }

    [XmlElement("departurePerShiftBudget")]
    [JsonPropertyName("departurePerShiftBudget")]
    public int? DeparturePerShiftBudget { get; init; }

    [XmlElement("departurePerShiftExtra")]
    [JsonPropertyName("departurePerShiftExtra")]
    public int? DeparturePerShiftExtra { get; init; }

    [XmlElement("brigadeProfileId")]
    [JsonPropertyName("brigadeProfileId")]
    public DepartAmbulanceBrigadeProfileId BrigadeProfileId { get; init; } = default!;

    [XmlElement("brigadeSpecId")]
    [JsonPropertyName("brigadeSpecId")]
    public BrigadeSpecId? BrigadeSpecId { get; init; }

    [XmlElement("brigadeTypeId")]
    [JsonPropertyName("brigadeTypeId")]
    public BrigadeTypeId BrigadeTypeId { get; init; } = default!;

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
