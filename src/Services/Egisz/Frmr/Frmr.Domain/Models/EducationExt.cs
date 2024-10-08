﻿// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.Domain;

public record EducationExt
{
    [XmlElement("extId")]
    [JsonPropertyName("extId")]
    public string? ExtId { get; init; }

    [XmlElement("profEducationKindId")]
    [JsonPropertyName("profEducationKindId")]
    public int ProfEducationKindId { get; init; }

    [XmlElement("profEducationKindName")]
    [JsonPropertyName("profEducationKindName")]
    public string? ProfEducationKindName { get; init; }

    [XmlElement("institutionId")]
    [JsonPropertyName("institutionId")]
    public int InstitutionId { get; init; }

    [XmlElement("institutionName")]
    [JsonPropertyName("institutionName")]
    public string? InstitutionName { get; init; }

    [XmlElement("hoursCount")]
    [JsonPropertyName("hoursCount")]
    public int HoursCount { get; init; }

    [XmlElement("theme")]
    [JsonPropertyName("theme")]
    public string Theme { get; init; } = default!;

    [XmlElement("docSerial")]
    [JsonPropertyName("docSerial")]
    public string? DocSerial { get; init; }

    [XmlElement("docNumber")]
    [JsonPropertyName("docNumber")]
    public string DocNumber { get; init; } = default!;

    [XmlElement("docDate")]
    [JsonPropertyName("docDate")]
    public DateTime DocDate { get; init; }

    [XmlElement("specId")]
    [JsonPropertyName("specId")]
    public int? SpecId { get; init; }

    [XmlElement("specName")]
    [JsonPropertyName("specName")]
    public string? SpecName { get; init; }
}
