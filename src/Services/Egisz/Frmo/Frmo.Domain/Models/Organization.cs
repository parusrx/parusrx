// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

[XmlRoot("organization")]
public record Organization
{
    [XmlElement("oid")]
    [JsonPropertyName("oid")]
    public string? Oid { get; init; }

    [XmlElement("headOid")]
    [JsonPropertyName("headOid")]
    public string? HeadOid { get; init; }

    [XmlElement("nameFull")]
    [JsonPropertyName("nameFull")]
    public string NameFull { get; init; } = default!;

    [XmlElement("nameShort")]
    [JsonPropertyName("nameShort")]
    public string NameShort { get; init; } = default!;

    [XmlElement("inn")]
    [JsonPropertyName("inn")]
    public string Inn { get; init; } = default!;

    [XmlElement("kpp")]
    [JsonPropertyName("kpp")]
    public string Kpp { get; init; } = default!;

    [XmlElement("ogrn")]
    [JsonPropertyName("ogrn")]
    public string Ogrn { get; init; } = default!;

    [XmlElement("ogrnDate")]
    [JsonPropertyName("ogrnDate")]
    public DateTime? OgrnDate { get; init; }

    [XmlElement("legalAddress")]
    [JsonPropertyName("legalAddress")]
    public Address LegalAddress { get; init; } = default!;

    [XmlElement("orgType")]
    [JsonPropertyName("orgType")]
    public OrganizationType OrgType { get; init; } = default!;

    [XmlArray("structure")]
    [XmlArrayItem("structureItem")]
    [JsonPropertyName("structure")]
    public Structure[] Structure { get; init; } = [];

    [XmlArray("lands")]
    [XmlArrayItem("landItem")]
    [JsonPropertyName("lands")]
    public Land[]? Lands { get; init; }

    [XmlElement("parkingArea")]
    [JsonPropertyName("parkingArea")]
    public double? ParkingArea { get; init; }

    [XmlElement("certSeries")]
    [JsonPropertyName("certSeries")]
    public string? CertSeries { get; init; }

    [XmlElement("certNumber")]
    [JsonPropertyName("certNumber")]
    public string? CertNumber { get; init; }

    [XmlElement("certDate")]
    [JsonPropertyName("certDate")]
    public DateTime? CertDate { get; init; }

    [XmlElement("regOrgName")]
    [JsonPropertyName("regOrgName")]
    public string RegOrgName { get; init; } = default!;

    [XmlElement("regDate")]
    [JsonPropertyName("regDate")]
    public DateTime? RegDate { get; init; }

    [XmlElement("regOrg")]
    [JsonPropertyName("regOrg")]
    public string RegOrg { get; init; } = default!;

    [XmlElement("regOrgAddress")]
    [JsonPropertyName("regOrgAddress")]
    public Address RegOrgAddress { get; init; } = default!;

    [XmlElement("lawFormNameFull")]
    [JsonPropertyName("lawFormNameFull")]
    public string? LawFormNameFull { get; init; }

    [XmlElement("moDeptId")]
    [JsonPropertyName("moDeptId")]
    public OrganizationAffilation? MoDeptId { get; init; }

    [XmlElement("okopfId")]
    [JsonPropertyName("okopfId")]
    public Okopf? OkopfId { get; init; }

    [XmlElement("founder")]
    [JsonPropertyName("founder")]
    public string? Founder { get; init; }

    [XmlElement("moAddress")]
    [JsonPropertyName("moAddress")]
    public OrganizationAddress MoAddress { get; init; } = default!;

    [XmlElement("deleteDate")]
    [JsonPropertyName("deleteDate")]
    public DateTime? DeleteDate { get; init; }

    [XmlElement("deleteReason")]
    [JsonPropertyName("deleteReason")]
    public OrganizationDeleteReason? DeleteReason { get; init; }

    [XmlElement("regionId")]
    [JsonPropertyName("regionId")]
    public Region RegionId { get; init; } = default!;

    [XmlArray("medicalSubjectId")]
    [XmlArrayItem("medicalSubjectIdItem")]
    [JsonPropertyName("medicalSubjectId")]
    public OrganizationMedicalSubject[] MedicalSubjectId { get; init; } = [];

    [XmlElement("oldOid")]
    [JsonPropertyName("oldOid")]
    public string? OldOid { get; init; }

    [XmlElement("moAgencyKindId")]
    [JsonPropertyName("moAgencyKindId")]
    public OrganizationAgencyKind? MoAgencyKindId { get; init; }

    [XmlElement("moAgencyProfileId")]
    [JsonPropertyName("moAgencyProfileId")]
    public OrganizationAgencyProfile? MoAgencyProfileId { get; init; }

    [XmlElement("moTerritoryId")]
    [JsonPropertyName("moTerritoryId")]
    public Territory? MoTerritoryId { get; init; }

    [XmlElement("moLevelId")]
    [JsonPropertyName("moLevelId")]
    public OrganizationLevel? MoLevelId { get; init; }

    [XmlElement("eoOrganizationType")]
    [JsonPropertyName("eoOrganizationType")]
    public EducationalOrganizationType? EoOrganizationType { get; init; }

    [XmlElement("email")]
    [JsonPropertyName("email")]
    public string Email { get; init; } = default!;

    [XmlElement("site")]
    [JsonPropertyName("site")]
    public string? Site { get; init; }

    [XmlElement("attachedPeople")]
    [JsonPropertyName("attachedPeople")]
    public int? AttachedPeople { get; init; }

    [XmlElement("medicalInformationSystem")]
    [JsonPropertyName("medicalInformationSystem")]
    public bool? MedicalInformationSystem { get; init; }

    [XmlElement("routingOKS")]
    [JsonPropertyName("routingOKS")]
    public string? RoutingOKS { get; init; }

    [XmlElement("routingNumber")]
    [JsonPropertyName("routingNumber")]
    public string? RoutingNumber { get; init; }

    [XmlElement("primaryVascular")]
    [JsonPropertyName("primaryVascular")]
    public bool PrimaryVascular { get; init; }

    [XmlArray("medicalAidForm")]
    [XmlArrayItem("medicalAidFormItem")]
    [JsonPropertyName("medicalAidForm")]
    public MedicalAidForm[]? MedicalAidForm { get; init; }

    [XmlArray("medicalAidConditions")]
    [XmlArrayItem("medicalAidConditionsItem")]
    [JsonPropertyName("medicalAidConditions")]
    public MedicalAidCondition[]? MedicalAidConditions { get; init; }

    [XmlElement("maxServiceDistance")]
    [JsonPropertyName("maxServiceDistance")]
    public int? MaxServiceDistance { get; init; }

    [XmlArray("mark")]
    [XmlArrayItem("markItem")]
    [JsonPropertyName("mark")]
    public Mark[]? Mark { get; init; }
}
