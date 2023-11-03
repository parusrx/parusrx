// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mis.API.Persons;

public record EducationPostgraduate
{
    [XmlElement("postgraduateId")]
    [JsonPropertyName("postgraduateId")]
    public string? PostgraduateId { get; set; }

    [XmlElement("isDuplicate")]
    [JsonPropertyName("isDuplicate")]
    public bool IsDuplicate { get; set; }

    [XmlElement("educPlace")]
    [JsonPropertyName("educPlace")]
    public int EducPlace { get; set; }

    [XmlElement("educationStageId")]
    [JsonPropertyName("educationStageId")]
    public int EducationStageId { get; set; }

    [XmlElement("educationStageName")]
    [JsonPropertyName("educationStageName")]
    public string? EducationStageName { get; set; }

    [XmlElement("isStudying")]
    [JsonPropertyName("isStudying")]
    public bool IsStudying { get; set; }

    [XmlElement("beginYear")]
    [JsonPropertyName("beginYear")]
    public int BeginYear { get; set; }

    [XmlElement("docSerial")]
    [JsonPropertyName("docSerial")]
    public string? DocSerial { get; set; }

    [XmlElement("docNumber")]
    [JsonPropertyName("docNumber")]
    public string? DocNumber { get; set; }

    [XmlElement("docDate")]
    [JsonPropertyName("docDate")]
    public DateTime? DocDate { get; set; }

    [XmlElement("institutionId")]
    [JsonPropertyName("institutionId")]
    public int? InstitutionId { get; set; }
    
    [XmlElement("institutionName")]
    [JsonPropertyName("institutionName")]
    public string? InstitutionName { get; set; }

    [XmlElement("academicDegreeId")]
    [JsonPropertyName("academicDegreeId")]
    public int? AcademicDegreeId { get; set; }

    [XmlElement("academicDegreeName")]
    [JsonPropertyName("academicDegreeName")]
    public string? AcademicDegreeName { get; set; }

    [XmlElement("scienceBranchId")]
    [JsonPropertyName("scienceBranchId")]
    public int? ScienceBranchId { get; set; }

    [XmlElement("scienceBranchName")]
    [JsonPropertyName("scienceBranchName")]
    public string? ScienceBranchName { get; set; }

    [XmlElement("specId")]
    [JsonPropertyName("specId")]
    public int? SpecId { get; set; }

    [XmlElement("specName")]
    [JsonPropertyName("specName")]
    public string? SpecName { get; set; }

    [XmlElement("doctSpecId")]
    [JsonPropertyName("doctSpecId")]
    public int? DoctSpecId { get; set; }

    [XmlElement("doctSpecName")]
    [JsonPropertyName("doctSpecName")]
    public string? DoctSpecName { get; set; }

    [XmlElement("additionSpecId")]
    [JsonPropertyName("additionSpecId")]
    public int? AdditionSpecId { get; set; }

    [XmlElement("additionSpecName")]
    [JsonPropertyName("additionSpecName")]
    public string? AdditionSpecName { get; set; }

    [XmlElement("isTargeted")]
    [JsonPropertyName("isTargeted")]
    public bool IsTargeted { get; set; }

    [XmlElement("targetedRegionId")]
    [JsonPropertyName("targetedRegionId")]
    public int? TargetedRegionId { get; set; }

    [XmlElement("dutyMonthsPeriod")]
    [JsonPropertyName("dutyMonthsPeriod")]
    public int? DutyMonthsPeriod { get; set; }

    [XmlElement("dutyYearsPeriod")]
    [JsonPropertyName("dutyYearsPeriod")]
    public int? DutyYearsPeriod { get; set; }

    [XmlElement("isTargetTerminated")]
    [JsonPropertyName("isTargetTerminated")]
    public bool IsTargetTerminated { get; set; }

    [XmlElement("terminationReasonId")]
    [JsonPropertyName("terminationReasonId")]
    public int? TerminationReasonId { get; set; }

    [XmlElement("dutyInfo")]
    [JsonPropertyName("dutyInfo")]
    public string? DutyInfo { get; set; }

    [XmlElement("oksmId")]
    [JsonPropertyName("oksmId")]
    public int? OksmId { get; set; }

    [XmlElement("oksmName")]
    [JsonPropertyName("oksmName")]
    public string? OksmName { get; set; }

    [XmlElement("unionRepublicId")]
    [JsonPropertyName("unionRepublicId")]
    public int? UnionRepublicId { get; set; }

    [XmlElement("unionRepublicName")]
    [JsonPropertyName("unionRepublicName")]
    public string? UnionRepublicName { get; set; }

    [XmlElement("foreignInstitution")]
    [JsonPropertyName("foreignInstitution")]
    public string? ForeignInstitution { get; set; }

    [XmlElement("hasForeignCert")]
    [JsonPropertyName("hasForeignCert")]
    public int? HasForeignCert { get; set; }

    [XmlElement("foreignCertSerial")]
    [JsonPropertyName("foreignCertSerial")]
    public string? ForeignCertSerial { get; set; }

    [XmlElement("foreignCertNumber")]
    [JsonPropertyName("foreignCertNumber")]
    public string? ForeignCertNumber { get; set; }

    [XmlElement("foreignCertDate")]
    [JsonPropertyName("foreignCertDate")]
    public DateTime? ForeignCertDate { get; set; }
}
