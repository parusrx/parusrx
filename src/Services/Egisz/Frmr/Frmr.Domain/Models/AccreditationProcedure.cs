﻿// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.Domain;

public record AccreditationProcedure
{
    [XmlElement("accreditationРrocedureId")]
    [JsonPropertyName("accreditationРrocedureId")]
    public string? AccreditationРrocedureId { get; init; }

    [XmlElement("registryNumber")]
    [JsonPropertyName("registryNumber")]
    public string? RegistryNumber { get; init; }

    [XmlArray("secretaries")]
    [XmlArrayItem("secretariesItem")]
    [JsonPropertyName("secretaries")]
    public Secretary[]? Secretaries { get; init; }

    [XmlArray("key")]
    [XmlArrayItem("keyItem")]
    [JsonPropertyName("key")]
    public Key[]? Key { get; init; }

    [XmlElement("applicationId")]
    [JsonPropertyName("applicationId")]
    public string? ApplicationId { get; init; }

    [XmlElement("firstName")]
    [JsonPropertyName("firstName")]
    public string? FirstName { get; init; }

    [XmlElement("patronymic")]
    [JsonPropertyName("patronymic")]
    public string? Patronymic { get; init; }

    [XmlElement("lastName")]
    [JsonPropertyName("lastName")]
    public string? LastName { get; init; }

    [XmlElement("accreditationKindId")]
    [JsonPropertyName("accreditationKindId")]
    public int? AccreditationKindId { get; init; }

    [XmlElement("accreditationKind")]
    [JsonPropertyName("accreditationKind")]
    public string? AccreditationKind { get; init; }

    [XmlElement("postId")]
    [JsonPropertyName("postId")]
    public int? PostId { get; init; }

    [XmlElement("post")]
    [JsonPropertyName("post")]
    public string? Post { get; init; }

    [XmlElement("spec")]
    [JsonPropertyName("spec")]
    public Spec? Spec { get; init; }

    [XmlElement("mpSpec")]
    [JsonPropertyName("mpSpec")]
    public MpSpec? MpSpec { get; init; }

    [XmlElement("profStandardId")]
    [JsonPropertyName("profStandardId")]
    public int? ProfStandardId { get; init; }

    [XmlElement("profStandard")]
    [JsonPropertyName("profStandard")]
    public string? ProfStandard { get; init; }

    [XmlElement("institutionId")]
    [JsonPropertyName("institutionId")]
    public int? InstitutionId { get; init; }

    [XmlElement("institution")]
    [JsonPropertyName("institution")]
    public string? Institution { get; init; }

    [XmlElement("accreditationActivityKind")]
    [JsonPropertyName("accreditationActivityKind")]
    public string? AccreditationActivityKind { get; init; }

    [XmlElement("passed")]
    [JsonPropertyName("passed")]
    public bool Passed { get; init; }

    [XmlElement("excluded")]
    [JsonPropertyName("excluded")]
    public bool Excluded { get; init; }

    [XmlElement("passDate")]
    [JsonPropertyName("passDate")]
    public DateTime? PassDate { get; init; }

    [XmlElement("endDate")]
    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }

    [XmlElement("protocolDate")]
    [JsonPropertyName("protocolDate")]
    public DateTime? ProtocolDate { get; init; }

    [XmlElement("protocolNumber")]
    [JsonPropertyName("protocolNumber")]
    public string? ProtocolNumber { get; init; }

    [XmlElement("educationLevel")]
    [JsonPropertyName("educationLevel")]
    public int? EducationLevel { get; init; }
}
