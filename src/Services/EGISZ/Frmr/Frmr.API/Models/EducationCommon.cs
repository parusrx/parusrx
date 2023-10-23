// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API;

public record EducationCommon
{
    [JsonPropertyName("commonId")]
    [XmlElement("commonId")]
    public string? CommonId { get; init; }

    [JsonPropertyName("institution")]
    [XmlElement("institution")]
    public required string Institution { get; init; }

    [JsonPropertyName("docSerial")]
    [XmlElement("docSerial")]
    public string? DocSerial { get; init; }

    [JsonPropertyName("docNumber")]
    [XmlElement("docNumber")]
    public required string DocNumber { get; init; }

    [JsonPropertyName("docDate")]
    [XmlElement("docDate")]
    public required DateTime DocDate { get; init; }

    [JsonPropertyName("profCourseSet")]
    [XmlElement("profCourseSet")]
    public List<ProfCourse>? ProfCourseSet { get; init; }
}
