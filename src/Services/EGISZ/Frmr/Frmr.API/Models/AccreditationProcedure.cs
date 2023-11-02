// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API;

public record AccreditationProcedure
{
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

    [XmlElement("specId")]
    [JsonPropertyName("specId")]
    public int? SpecId { get; init; }

    [XmlElement("spec")]
    [JsonPropertyName("spec")]
    public string? Spec { get; init; }

    [XmlElement("mpSpecId")]
    [JsonPropertyName("mpSpecId")]
    public int? MpSpecId { get; init; }

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
