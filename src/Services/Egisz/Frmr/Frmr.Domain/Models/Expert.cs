// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.Domain;

public record Expert
{
    [XmlElement("docSerial")]
    [JsonPropertyName("docSerial")]
    public string? DocSerial { get; init; }

    [XmlElement("docNumber")]
    [JsonPropertyName("docNumber")]
    public string? DocNumber { get; init; }

    [XmlElement("docDate")]
    [JsonPropertyName("docDate")]
    public DateTime? DocDate { get; init; }

    [XmlElement("endDate")]
    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }

    [XmlElement("institution")]
    [JsonPropertyName("institution")]
    public Institution? Institution { get; init; }

    [XmlElement("spec")]
    [JsonPropertyName("spec")]
    public Spec? Spec { get; init; }
}
