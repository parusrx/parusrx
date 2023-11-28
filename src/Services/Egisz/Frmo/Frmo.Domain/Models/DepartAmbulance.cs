// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Domain;

public record DepartAmbulance
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public int Id { get; init; }

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
}
