// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record MobileDepart
{
    [XmlElement("mobileDepartId")]
    [JsonPropertyName("mobileDepartId")]
    public string? MobileDepartId { get; set; }

    [XmlElement("mobileDepartName")]
    [JsonPropertyName("mobileDepartName")]
    public string MobileDepartName { get; set; } = default!;

    [XmlElement("buildingId")]
    [JsonPropertyName("buildingId")]
    public string BuildingId { get; set; } = default!;

    [XmlElement("buildingName")]
    [JsonPropertyName("buildingName")]
    public string BuildingName { get; set; } = default!;

    [XmlElement("departId")]
    [JsonPropertyName("departId")]
    public string DepartId { get; set; } = default!;

    [XmlElement("departName")]
    [JsonPropertyName("departName")]
    public string DepartName { get; set; } = default!;

    [XmlElement("departureCount")]
    [JsonPropertyName("departureCount")]
    public int DepartureCount { get; set; }

    [XmlElement("paymentSourceId")]
    [JsonPropertyName("paymentSourceId")]
    public MobileDepartPaymentSourceId PaymentSourceId { get; set; } = default!;

    [XmlElement("typeId")]
    [JsonPropertyName("typeId")]
    public MobileDepartTypeId TypeId { get; set; } = default!;

    [XmlElement("patientCount")]
    [JsonPropertyName("patientCount")]
    public int? PatientCount { get; set; }

    [XmlArray("vehicle")]
    [XmlArrayItem("vehicleItem")]
    [JsonPropertyName("vehicle")]
    public MobileDepartVehicle[]? Vehicle { get; set; }

    [XmlArray("addresses")]
    [XmlArrayItem("addressesItem")]
    [JsonPropertyName("addresses")]
    public MobileDepartAddress[] Addresses { get; set; } = [];
}
