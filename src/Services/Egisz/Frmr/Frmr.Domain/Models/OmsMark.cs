// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.Domain;

public record OmsMark
{
    [XmlArray("preferentialPrescriptions")]
    [XmlArrayItem("preferentialPrescriptionsItem")]
    [JsonPropertyName("preferentialPrescriptions")]
    public PreferentialPrescription[]? PreferentialPrescriptions { get; init; }

    [XmlElement("certId")]
    [JsonPropertyName("certId")]
    public string? CertId { get; init; }

    [XmlElement("accreditationId")]
    [JsonPropertyName("accreditationId")]
    public string? AccreditationId { get; init; }

    [XmlElement("accreditationРrocedureId")]
    [JsonPropertyName("accreditationРrocedureId")]
    public string? AccreditationProcedureId { get; init; }

    [XmlArray("experts")]
    [XmlArrayItem("expertsItem")]
    [JsonPropertyName("experts")]
    public Expert[]? Experts { get; init; }
}
