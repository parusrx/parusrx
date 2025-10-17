// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.Domain;

public record EducationProf
{
    [XmlElement("isStudentEducation")]
    [JsonPropertyName("isStudentEducation")]
    public bool? IsStudentEducation { get; init; }

    [XmlElement("profId")]
    [JsonPropertyName("profId")]
    public string? ProfId { get; init; }

    [XmlElement("isDuplicate")]
    [JsonPropertyName("isDuplicate")]
    public bool? IsDuplicate { get; init; }

    [XmlElement("educPlace")]
    [JsonPropertyName("educPlace")]
    public int? EducPlace { get; init; }

    [XmlElement("educationTypeId")]
    [JsonPropertyName("educationTypeId")]
    public EducationTypeId? EducationTypeId { get; init; }

    [XmlElement("beginYear")]
    [JsonPropertyName("beginYear")]
    public int? BeginYear { get; init; }

    [XmlElement("enrollmentDate")]
    [JsonPropertyName("enrollmentDate")]
    public DateTime? EnrollmentDate { get; init; }

    [XmlArray("courses")]
    [XmlArrayItem("coursesItem")]
    [JsonPropertyName("courses")]
    public Course[]? Courses { get; init; }

    [XmlElement("hasDiploma")]
    [JsonPropertyName("hasDiploma")]
    public bool? HasDiploma { get; init; }

    [XmlElement("docSerial")]
    [JsonPropertyName("docSerial")]
    public string? DocSerial { get; init; }

    [XmlElement("docNumber")]
    [JsonPropertyName("docNumber")]
    public string DocNumber { get; init; } = default!;

    [XmlElement("docDate")]
    [JsonPropertyName("docDate")]
    public DateTime? DocDate { get; init; }

    [XmlElement("institutionId")]
    [JsonPropertyName("institutionId")]
    public int? InstitutionId { get; init; }

    [XmlElement("institutionName")]
    [JsonPropertyName("institutionName")]
    public string? InstitutionName { get; init; }

    [XmlElement("levelEducationId")]
    [JsonPropertyName("levelEducationId")]
    public int? LevelEducationId { get; init; }

    [XmlElement("formEducation")]
    [JsonPropertyName("formEducation")]
    public string? FormEducation { get; init; }

    [XmlElement("educationProgramDurationYears")]
    [JsonPropertyName("educationProgramDurationYears")]
    public int? EducationProgramDurationYears { get; init; }

    [XmlElement("educationProgramDurationMonths")]
    [JsonPropertyName("educationProgramDurationMonths")]
    public int? EducationProgramDurationMonths { get; init; }

    [XmlElement("budget")]
    [JsonPropertyName("budget")]
    public bool? Budget { get; init; }

    [XmlElement("specId")]
    [JsonPropertyName("specId")]
    public int? SpecId { get; init; }

    [XmlElement("specName")]
    [JsonPropertyName("specName")]
    public string? SpecName { get; init; }

    [XmlElement("qualificationId")]
    [JsonPropertyName("qualificationId")]
    public int? QualificationId { get; init; }

    [XmlElement("qualificationName")]
    [JsonPropertyName("qualificationName")]
    public string? QualificationName { get; init; }

    [XmlElement("isTargeted")]
    [JsonPropertyName("isTargeted")]
    public bool? IsTargeted { get; init; }

    [XmlElement("targetedRegionId")]
    [JsonPropertyName("targetedRegionId")]
    public int? TargetedRegionId { get; init; }

    [XmlElement("dutyMonthsPeriod")]
    [JsonPropertyName("dutyMonthsPeriod")]
    public int? DutyMonthsPeriod { get; init; }

    [XmlElement("dutyYearsPeriod")]
    [JsonPropertyName("dutyYearsPeriod")]
    public int? DutyYearsPeriod { get; init; }

    [XmlElement("isTargetTerminated")]
    [JsonPropertyName("isTargetTerminated")]
    public bool? IsTargetTerminated { get; init; }

    [XmlElement("terminationReasonId")]
    [JsonPropertyName("terminationReasonId")]
    public int? TerminationReasonId { get; init; }

    [XmlElement("dutyInfo")]
    [JsonPropertyName("dutyInfo")]
    public string? DutyInfo { get; init; }

    [XmlElement("oksmId")]
    [JsonPropertyName("oksmId")]
    public int? OksmId { get; init; }

    [XmlElement("oksmName")]
    [JsonPropertyName("oksmName")]
    public string? OksmName { get; init; }

    [XmlElement("unionRepublicId")]
    [JsonPropertyName("unionRepublicId")]
    public int? UnionRepublicId { get; init; }

    [XmlElement("unionRepublicName")]
    [JsonPropertyName("unionRepublicName")]
    public string? UnionRepublicName { get; init; }

    [XmlElement("foreignInstitution")]
    [JsonPropertyName("foreignInstitution")]
    public string? ForeignInstitution { get; init; }

    [XmlElement("hasForeignCert")]
    [JsonPropertyName("hasForeignCert")]
    public int? HasForeignCert { get; init; }

    [XmlElement("foreignCertSerial")]
    [JsonPropertyName("foreignCertSerial")]
    public string? ForeignCertSerial { get; init; }

    [XmlElement("foreignCertNumber")]
    [JsonPropertyName("foreignCertNumber")]
    public string? ForeignCertNumber { get; init; }

    [XmlElement("foreignCertDate")]
    [JsonPropertyName("foreignCertDate")]
    public DateTime? ForeignCertDate { get; init; }

    [XmlElement("customerContractDate")]
    [JsonPropertyName("customerContractDate")]
    public DateTime? CustomerContractDate { get; init; }

    [XmlElement("customerContractNumber")]
    [JsonPropertyName("customerContractNumber")]
    public string? CustomerContractNumber { get; init; }

    [XmlElement("customerName")]
    [JsonPropertyName("customerName")]
    public string? CustomerName { get; init; }

    [XmlElement("сustomerInn")]
    [JsonPropertyName("сustomerInn")]
    public string? СustomerInn { get; init; }

    [XmlElement("customerOgrn")]
    [JsonPropertyName("customerOgrn")]
    public string? CustomerOgrn { get; init; }

    [XmlElement("isMatchEmployingOrganization")]
    [JsonPropertyName("isMatchEmployingOrganization")]
    public bool? IsMatchEmployingOrganization { get; init; }

    [XmlElement("employingOrganizationName")]
    [JsonPropertyName("employingOrganizationName")]
    public string? EmployingOrganizationName { get; init; }

    [XmlElement("employingOrganizationInn")]
    [JsonPropertyName("employingOrganizationInn")]
    public string? EmployingOrganizationInn { get; init; }

    [XmlElement("employingOrganizationOgrn")]
    [JsonPropertyName("employingOrganizationOgrn")]
    public string? EmployingOrganizationOgrn { get; init; }
}
