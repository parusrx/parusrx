// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.Domain;

[JsonDerivedType(typeof(FullPerson))]
public record Person
{
    [XmlElement("mr")]
    [JsonPropertyName("mr")]
    [JsonPropertyOrder(-1)]
    public bool Mr { get; init; }

    [XmlElement("student")]
    [JsonPropertyName("student")]
    [JsonPropertyOrder(-1)]
    public bool Student { get; init; }

    [XmlElement("oid")]
    [JsonPropertyName("oid")]
    [JsonPropertyOrder(-1)]
    public string? Oid { get; init; }

    [XmlElement("lastName")]
    [JsonPropertyName("lastName")]
    [JsonPropertyOrder(-1)]
    public string LastName { get; init; } = string.Empty;

    [XmlElement("firstName")]
    [JsonPropertyName("firstName")]
    [JsonPropertyOrder(-1)]
    public string FirstName { get; init; } = string.Empty;

    [XmlElement("patronymic")]
    [JsonPropertyName("patronymic")]
    [JsonPropertyOrder(-1)]
    public string? Patronymic { get; init; }

    [XmlElement("gender")]
    [JsonPropertyName("gender")]
    [JsonPropertyOrder(-1)]
    public int Gender { get; init; }

    [XmlElement("birthDate")]
    [JsonPropertyName("birthDate")]
    [JsonPropertyOrder(-1)]
    public DateTime BirthDate { get; init; }

    [XmlElement("snils")]
    [JsonPropertyName("snils")]
    [JsonPropertyOrder(-1)]
    public string? Snils { get; init; }

    [XmlElement("inn")]
    [JsonPropertyName("inn")]
    [JsonPropertyOrder(-1)]
    public string? Inn { get; init; }

    [XmlElement("citizenShipId")]
    [JsonPropertyName("citizenShipId")]
    [JsonPropertyOrder(-1)]
    public CitizenShipId CitizenShipId { get; init; } = new();

    [XmlElement("oksmId")]
    [JsonPropertyName("oksmId")]
    [JsonPropertyOrder(-1)]
    public OksmId? OksmId { get; init; }

    [XmlElement("militaryRelationId")]
    [JsonPropertyName("militaryRelationId")]
    [JsonPropertyOrder(-1)]
    public int? MilitaryRelationId { get; init; }

    [XmlElement("phone")]
    [JsonPropertyName("phone")]
    [JsonPropertyOrder(-1)]
    public string? Phone { get; init; }

    [XmlElement("email")]
    [JsonPropertyName("email")]
    [JsonPropertyOrder(-1)]
    public string? Email { get; init; }

    [XmlElement("isDisabled")]
    [JsonPropertyName("isDisabled")]
    [JsonPropertyOrder(-1)]
    public bool? IsDisabled { get; init; }

    [XmlElement("disabledGroupId")]
    [JsonPropertyName("disabledGroupId")]
    [JsonPropertyOrder(-1)]
    public int? DisabledGroupId { get; init; }

    [XmlElement("disabledGroupName")]
    [JsonPropertyName("disabledGroupName")]
    [JsonPropertyOrder(-1)]
    public string? DisabledGroupName { get; init; }

    [XmlElement("disabledDate")]
    [JsonPropertyName("disabledDate")]
    [JsonPropertyOrder(-1)]
    public DateTime? DisabledDate { get; init; }

    [XmlElement("covid19")]
    [JsonPropertyName("covid19")]
    [JsonPropertyOrder(-1)]
    public bool? Covid19 { get; init; }

    [XmlArray("documents")]
    [XmlArrayItem("documentsItem")]
    [JsonPropertyName("documents")]
    [JsonPropertyOrder(-1)]
    public PersonDocument[]? Documents { get; init; }

    [XmlArray("addresses")]
    [XmlArrayItem("addressesItem")]
    [JsonPropertyName("addresses")]
    [JsonPropertyOrder(-1)]
    public AddressDescription[]? Addresses { get; init; }
}
