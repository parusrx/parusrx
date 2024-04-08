// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record Equipment
{
    [XmlElement("equipmentId")]
    [JsonPropertyName("equipmentId")]
    public string? EquipmentId { get; set; }

    [XmlElement("building")]
    [JsonPropertyName("building")]
    public EquipmentBuilding? Building { get; set; }

    [XmlElement("depart")]
    [JsonPropertyName("depart")]
    public EquipmentDepart? Depart { get; set; }

    [XmlElement("type")]
    [JsonPropertyName("type")]
    public string Type { get; set; } = default!;

    [XmlElement("anotherAddress")]
    [JsonPropertyName("anotherAddress")]
    public Address? AnotherAddress { get; set; }

    [XmlElement("anotherAddressReason")]
    [JsonPropertyName("anotherAddressReason")]
    public string? AnotherAddressReason { get; set; }

    [XmlElement("equipmentSection")]
    [JsonPropertyName("equipmentSection")]
    public EquipmentSection EquipmentSection { get; set; } = default!;

    [XmlElement("equipmentType")]
    [JsonPropertyName("equipmentType")]
    public EquipmentType EquipmentType { get; set; } = default!;

    [XmlElement("equipmentName")]
    [JsonPropertyName("equipmentName")]
    public string EquipmentName { get; set; } = default!;

    [XmlElement("equipmentTypeId")]
    [JsonPropertyName("equipmentTypeId")]
    public int? EquipmentTypeId { get; set; }

    [XmlElement("vendor")]
    [JsonPropertyName("vendor")]
    public string Vendor { get; set; } = default!;

    [XmlElement("oksmId")]
    [JsonPropertyName("oksmId")]
    public string? OksmId { get; set; }

    [XmlElement("model")]
    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [XmlElement("registrationCertificate")]
    [JsonPropertyName("registrationCertificate")]
    public string? RegistrationCertificate { get; set; }

    [XmlElement("registrationDate")]
    [JsonPropertyName("registrationDate")]
    public DateTime? RegistrationDate { get; set; }

    [XmlElement("serialNumber")]
    [JsonPropertyName("serialNumber")]
    public string SerialNumber { get; set; } = default!;

    [XmlElement("inventoryNumber")]
    [JsonPropertyName("inventoryNumber")]
    public string InventoryNumber { get; set; } = default!;

    [XmlElement("productDate")]
    [JsonPropertyName("productDate")]
    public DateTime ProductDate { get; set; }

    [XmlElement("beginDate")]
    [JsonPropertyName("beginDate")]
    public DateTime BeginDate { get; set; }

    [XmlElement("lifeTime")]
    [JsonPropertyName("lifeTime")]
    public int LifeTime { get; set; }

    [XmlElement("needReplace")]
    [JsonPropertyName("needReplace")]
    public bool? NeedReplace { get; set; }

    [XmlElement("isShared")]
    [JsonPropertyName("isShared")]
    public bool? IsShared { get; set; }

    [XmlElement("count")]
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [XmlElement("endDate")]
    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; set; }

    [XmlElement("endReason")]
    [JsonPropertyName("endReason")]
    public string? EndReason { get; set; }
}
