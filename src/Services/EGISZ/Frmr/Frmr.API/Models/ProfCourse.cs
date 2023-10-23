// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API;

public record ProfCourse
{
    [JsonPropertyName("docDate")]
    [XmlElement("docDate")]
    public required DateTime DocDate { get; init; }

    [JsonPropertyName("profCourseId")]
    [XmlElement("profCourseId")]
    public int ProfCourseId { get; init; }

    [JsonPropertyName("profCourseName")]
    [XmlElement("profCourseName")]
    public string ProfCourseName { get; init; } = default!;
}
