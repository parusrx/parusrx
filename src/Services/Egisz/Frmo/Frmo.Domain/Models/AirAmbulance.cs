// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record AirAmbulance
{
    [XmlElement("airAmbulanceId")]
    [JsonPropertyName("airAmbulanceId")]
    public string AirAmbulanceId { get; init; } = default!;

    [XmlElement("airAmbulanceName")]
    [JsonPropertyName("airAmbulanceName")]
    public string? AirAmbulanceName { get; init; }

    [XmlElement("depart")]
    [JsonPropertyName("depart")]
    public AirAmbulanceDepart Depart { get; init; } = default!;

    [XmlElement("address")]
    [JsonPropertyName("address")]
    public Address Address { get; init; } = default!;

    [XmlElement("addressLatitude")]
    [JsonPropertyName("addressLatitude")]
    public double AddressLatitude { get; init; }

    [XmlElement("addressLongitude")]
    [JsonPropertyName("addressLongitude")]
    public double AddressLongitude { get; init; }

    [XmlElement("hasHelicopter")]
    [JsonPropertyName("hasHelicopter")]
    public bool HasHelicopter { get; init; }

    [XmlElement("nightStart")]
    [JsonPropertyName("nightStart")]
    public bool? NightStart { get; init; }

    [XmlElement("nightStartPossibility")]
    [JsonPropertyName("nightStartPossibility")]
    public int? NightStartPossibility { get; init; }

    [XmlElement("helipadCount")]
    [JsonPropertyName("helipadCount")]
    public int HelipadCount { get; init; }

    [XmlElement("helipadNightStart")]
    [JsonPropertyName("helipadNightStart")]
    public int? HelipadNightStart { get; init; }

    [XmlElement("weightRestrictions")]
    [JsonPropertyName("weightRestrictions")]
    public int? WeightRestrictions { get; init; }

    [XmlElement("farHelipadCount")]
    [JsonPropertyName("farHelipadCount")]
    public int FarHelipadCount { get; init; }

    [XmlElement("farHelipadNightStart")]
    [JsonPropertyName("farHelipadNightStart")]
    public int? FarHelipadNightStart { get; init; }

    [XmlElement("farHelipadWeightRestrictions")]
    [JsonPropertyName("farHelipadWeightRestrictions")]
    public int? FarHelipadWeightRestrictions { get; init; }

    [XmlArray("helipadAddresses")]
    [XmlArrayItem("helipadAddressesItem")]
    [JsonPropertyName("helipadAddresses")]
    public AirAmbulanceHelipadAddress[] HelipadAddresses { get; init; } = [];

    [XmlElement("reanimationHelipadCount")]
    [JsonPropertyName("reanimationHelipadCount")]
    public int ReanimationHelipadCount { get; init; }

    [XmlElement("nonReanimationHelipadCount")]
    [JsonPropertyName("nonReanimationHelipadCount")]
    public int NonReanimationHelipadCount { get; init; }

    [XmlArray("helicopterEquipment")]
    [XmlArrayItem("helicopterEquipmentItem")]
    [JsonPropertyName("helicopterEquipment")]
    public string[]? HelicopterEquipment { get; init; }

    [XmlElement("reanimobileCount")]
    [JsonPropertyName("reanimobileCount")]
    public int ReanimobileCount { get; init; }

    [XmlArray("reanimobileAddresses")]
    [XmlArrayItem("reanimobileAddressesItem")]
    [JsonPropertyName("reanimobileAddresses")]
    public AirAmbulanceReanimobileAddress[] ReanimobileAddresses { get; init; } = [];

    [XmlArray("reanimobileEquipment")]
    [XmlArrayItem("reanimobileEquipmentItem")]
    [JsonPropertyName("reanimobileEquipment")]
    public string[]? ReanimobileEquipment { get; init; }
}
