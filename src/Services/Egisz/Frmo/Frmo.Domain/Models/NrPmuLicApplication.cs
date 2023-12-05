// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Domain;

public record NrPmuLicApplication
{
    [XmlElement("appNumber")]
    [JsonPropertyName("appNumber")]
    public string? AppNumber { get; init; }

    [XmlElement("appDate")]
    [JsonPropertyName("appDate")]
    public DateTime? AppDate { get; init; }

    [XmlElement("status")]
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [XmlArray("nrPmuLicAppobj")]
    [XmlArrayItem("nrPmuLicAppobjItem")]
    [JsonPropertyName("nrPmuLicAppobj")]
    public NrPmuLicAppObj[]? NrPmuLicAppObj { get; init; }
}
