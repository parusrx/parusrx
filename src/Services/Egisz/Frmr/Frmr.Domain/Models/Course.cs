// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.Domain;

public record Course
{
    [XmlElement("enrollmentRate")]
    [JsonPropertyName("enrollmentRate")]
    public int EnrollmentRate { get; init; }

    [XmlElement("structuralUnitStudent")]
    [JsonPropertyName("structuralUnitStudent")]
    public string StructuralUnitStudent { get; init; } = default!;

    [XmlElement("enrollmentSpecialtyId")]
    [JsonPropertyName("enrollmentSpecialtyId")]
    public int EnrollmentSpecialtyId { get; init; }

    [XmlElement("learningOutcomeId")]
    [JsonPropertyName("learningOutcomeId")]
    public int? LearningOutcomeId { get; init; }

    [XmlElement("protocolNumber")]
    [JsonPropertyName("protocolNumber")]
    public string? ProtocolNumber { get; init; }

    [XmlElement("dateIssueProtocol")]
    [JsonPropertyName("dateIssueProtocol")]
    public DateTime? DateIssueProtocol { get; init; }

    [XmlElement("diplomaQualificationId")]
    [JsonPropertyName("diplomaQualificationId")]
    public int? DiplomaQualificationId { get; init; }

    [XmlElement("reasonForExpulsionId")]
    [JsonPropertyName("reasonForExpulsionId")]
    public int? ReasonForExpulsionId { get; init; }

    [XmlElement("dateDeduction")]
    [JsonPropertyName("dateDeduction")]
    public DateTime? DateDeduction { get; init; }

    [XmlElement("transferDate")]
    [JsonPropertyName("transferDate")]
    public DateTime? TransferDate { get; init; }
    
    [XmlElement("dateAcademicLeave")]
    [JsonPropertyName("dateAcademicLeave")]
    public DateTime? DateAcademicLeave { get; init; }

    [XmlElement("educationalOrgEndCourseId")]
    [JsonPropertyName("educationalOrgEndCourseId")]
    public int EducationalOrgEndCourseId { get; init; }

    [XmlElement("academicDegreeId")]
    [JsonPropertyName("academicDegreeId")]
    public int? AcademicDegreeId { get; init; }

    [XmlElement("scientificDegreeId")]
    [JsonPropertyName("scientificDegreeId")]
    public int? ScientificDegreeId { get; init; }
}
