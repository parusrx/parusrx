// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.Domain;

public record PersonAccreditation
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [XmlElement("protocolDate")]
    [JsonPropertyName("protocolDate")]
    public DateTime? ProtocolDate { get; init; }

    [XmlElement("protocolNumber")]
    [JsonPropertyName("protocolNumber")]
    public string? ProtocolNumber { get; init; }

    [XmlElement("docSerial")]
    [JsonPropertyName("docSerial")]
    public string? DocSerial { get; init; }

    [XmlElement("docNumber")]
    [JsonPropertyName("docNumber")]
    public string? DocNumber { get; init; }

    [XmlElement("regNumber")]
    [JsonPropertyName("regNumber")]
    public string? RegNumber { get; init; }

    [XmlArray("accreditationProcedures")]
    [XmlArrayItem("accreditationProceduresItem")]
    [JsonPropertyName("accreditationProcedures")]
    public AccreditationProcedure[]? AccreditationProcedures { get; init; }
}
