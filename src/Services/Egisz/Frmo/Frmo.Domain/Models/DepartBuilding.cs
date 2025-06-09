// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record DepartBuilding
{
    [XmlElement("buildingId")]
    [JsonPropertyName("buildingId")]
    public string BuildingId { get; init; } = default!;

    [XmlElement("buildingName")]
    [JsonPropertyName("buildingName")]
    public string BuildingName { get; init; } = default!;

    [XmlElement("patientAttached")]
    [JsonPropertyName("patientAttached")]
    public int? PatientAttached { get; init; }

    [XmlElement("childAttached")]
    [JsonPropertyName("childAttached")]
    public int? ChildAttached { get; init; }

    [XmlElement("patientAttachedWomen")]
    [JsonPropertyName("patientAttachedWomen")]
    public int? PatientAttachedWomen { get; init; }

    [XmlElement("patientAttachedAged")]
    [JsonPropertyName("patientAttachedAged")]
    public int? PatientAttachedAged { get; init; }

    [XmlElement("patientService")]
    [JsonPropertyName("patientService")]
    public int? PatientService { get; init; }

    [XmlElement("patientServiceWomen")]
    [JsonPropertyName("patientServiceWomen")]
    public int? PatientServiceWomen { get; init; }

    [XmlElement("patientServiceChild")]
    [JsonPropertyName("patientServiceChild")]
    public int? PatientServiceChild { get; init; }

    [XmlElement("patientServiceAged")]
    [JsonPropertyName("patientServiceAged")]
    public int? PatientServiceAged { get; init; }

    [XmlElement("visitPerShift")]
    [JsonPropertyName("visitPerShift")]
    public int? VisitPerShift { get; init; }

    [XmlElement("visitPerShiftChild")]
    [JsonPropertyName("visitPerShiftChild")]
    public int? VisitPerShiftChild { get; init; }

    [XmlElement("visitPerShiftWomen")]
    [JsonPropertyName("visitPerShiftWomen")]
    public int? VisitPerShiftWomen { get; init; }

    [XmlElement("visitPerShiftAged")]
    [JsonPropertyName("visitPerShiftAged")]
    public int? VisitPerShiftAged { get; init; }

    [XmlArray("services")]
    [XmlArrayItem("servicesItem")]
    [JsonPropertyName("services")]
    public Service[]? Services { get; init; }

    [XmlArray("floors")]
    [XmlArrayItem("floorsItem")]
    [JsonPropertyName("floors")]
    public DepartBuildingFloor[]? Floors { get; init; }
}
