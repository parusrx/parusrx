// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API;

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
