﻿// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.Domain;

public record EducationCommon
{
    [XmlElement("commonId")]
    [JsonPropertyName("commonId")]
    public string? CommonId { get; init; }

    [XmlElement("institution")]
    [JsonPropertyName("institution")]
    public string Institution { get; init; } = default!;

    [XmlElement("docSerial")]
    [JsonPropertyName("docSerial")]
    public string? DocSerial { get; init; }

    [XmlElement("docNumber")]
    [JsonPropertyName("docNumber")]
    public string DocNumber { get; init; } = default!;

    [XmlElement("docDate")]
    [JsonPropertyName("docDate")]
    public DateTime DocDate { get; init; }

    [XmlElement("profCourseSet")]
    [JsonPropertyName("profCourseSet")]
    public ProfCourse[]? ProfCourseSet { get; init; }
}
