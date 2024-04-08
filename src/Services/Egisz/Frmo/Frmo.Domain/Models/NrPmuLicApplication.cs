// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

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
