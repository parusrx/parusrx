// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.Domain;

public record EducationCert
{
    [XmlElement("certId")]
    [JsonPropertyName("certId")]
    public string? CertId { get; init; }

    [XmlElement("institutionId")]
    [JsonPropertyName("institutionId")]
    public int InstitutionId { get; init; }

    [XmlElement("institutionName")]
    [JsonPropertyName("institutionName")]
    public string? InstitutionName { get; init; }

    [XmlElement("certSerial")]
    [JsonPropertyName("certSerial")]
    public string? CertSerial { get; init; }

    [XmlElement("certNumber")]
    [JsonPropertyName("certNumber")]
    public string CertNumber { get; init; } = default!;

    [XmlElement("examDate")]
    [JsonPropertyName("examDate")]
    public DateTime ExamDate { get; init; }

    [XmlElement("passDate")]
    [JsonPropertyName("passDate")]
    public DateTime? PassDate { get; init; }

    [XmlElement("endDate")]
    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }

    [XmlElement("specId")]
    [JsonPropertyName("specId")]
    public int SpecId { get; init; }

    [XmlElement("specName")]
    [JsonPropertyName("specName")]
    public string? SpecName { get; init; }
}
