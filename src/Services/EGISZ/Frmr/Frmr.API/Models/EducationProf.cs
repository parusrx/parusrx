// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API;

public record EducationProf
{
    [JsonPropertyName("isStudentEducation")]
    [XmlElement("isStudentEducation")]
    public bool IsStudentEducation { get; init; }

    [JsonPropertyName("profId")]
    [XmlElement("profId")]
    public string ProfId { get; init; } = default!;

    [JsonPropertyName("isDuplicate")]
    [XmlElement("isDuplicate")]
    public bool IsDuplicate { get; init; }

    [JsonPropertyName("educPlace")]
    [XmlElement("educPlace")]
    public int? EducPlace { get; init; }

    [JsonPropertyName("educationTypeId")]
    [XmlElement("educationTypeId")]
    public EducationTypeId EducationTypeId { get; init; } = default!;

    [JsonPropertyName("beginYear")]
    [XmlElement("beginYear")]
    public int? BeginYear { get; init; }

    [JsonPropertyName("enrollmentDate")]
    [XmlElement("enrollmentDate")]
    public DateTime? EnrollmentDate { get; init; }
}
