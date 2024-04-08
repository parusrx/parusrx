// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.Domain;

public record ProfCourse
{
    [XmlElement("docDate")]
    [JsonPropertyName("docDate")]
    public DateTime DocDate { get; init; }

    [XmlElement("profCourseId")]
    [JsonPropertyName("profCourseId")]
    public int ProfCourseId { get; init; }

    [XmlElement("profCourseName")]
    [JsonPropertyName("profCourseName")]
    public string ProfCourseName { get; init; } = default!;
}
