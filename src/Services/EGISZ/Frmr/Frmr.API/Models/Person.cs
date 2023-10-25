// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API;

public record Person
{
    [XmlElement("mr")]
    [JsonPropertyName("mr")]
    public bool Mr { get; init; }

    [XmlElement("student")]
    [JsonPropertyName("student")]
    public bool Student { get; init; }

    [XmlElement("oid")]
    [JsonPropertyName("oid")]
    public string? Oid { get; init; }

    [XmlElement("lastName")]
    [JsonPropertyName("lastName")]
    public string LastName { get; init; } = string.Empty;

    [XmlElement("firstName")]
    [JsonPropertyName("firstName")]
    public string FirstName { get; init; } = string.Empty;

    [XmlElement("patronymic")]
    [JsonPropertyName("patronymic")]
    public string? Patronymic { get; init; }

    [XmlElement("gender")]
    [JsonPropertyName("gender")]
    public int Gender { get; init; }

    [XmlElement("birthDate")]
    [JsonPropertyName("birthDate")]
    public DateTime BirthDate { get; init; }

    [XmlElement("snils")]
    [JsonPropertyName("snils")]
    public string? Snils { get; init; }

    [XmlElement("inn")]
    [JsonPropertyName("inn")]
    public string? Inn { get; init; }

    [XmlElement("citizenShipId")]
    [JsonPropertyName("citizenShipId")]
    public СitizenShipId CitizenShipId { get; init; } = new();

    [XmlElement("oksmId")]
    [JsonPropertyName("oksmId")]
    public OksmId? OksmId { get; init; }

    [XmlElement("militaryRelationId")]
    [JsonPropertyName("militaryRelationId")]
    public int? MilitaryRelationId { get; init; }

    [XmlElement("phone")]
    [JsonPropertyName("phone")]
    public string? Phone { get; init; }

    [XmlElement("email")]
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    [XmlElement("isDisabled")]
    [JsonPropertyName("isDisabled")]
    public bool? IsDisabled { get; init; }

    [XmlElement("disabledGroupId")]
    [JsonPropertyName("disabledGroupId")]
    public int? DisabledGroupId { get; init; }

    [XmlElement("disabledGroupName")]
    [JsonPropertyName("disabledGroupName")]
    public string? DisabledGroupName { get; init; }

    [XmlElement("disabledDate")]
    [JsonPropertyName("disabledDate")]
    public DateTime? DisabledDate { get; init; }

    [XmlElement("covid19")]
    [JsonPropertyName("covid19")]
    public bool? Covid19 { get; init; }

    [XmlArray("documents")]
    [XmlArrayItem("documentsItem")]
    [JsonPropertyName("documents")]
    public PersonDocument[]? Documents { get; init; }

    [XmlArray("addresses")]
    [XmlArrayItem("addressesItem")]
    [JsonPropertyName("addresses")]
    public AddressDescription[]? Addresses { get; init; }
}
