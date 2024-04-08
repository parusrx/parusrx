// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record NrPmuLicAppObj
{
    [XmlElement("typeId")]
    [JsonPropertyName("typeId")]
    public NrPmuLicAppObjTypeId? TypeId { get; init; }

    [XmlElement("address")]
    [JsonPropertyName("address")]
    public Address? Address { get; init; }

    [XmlElement("status")]
    [JsonPropertyName("status")]
    public int? Status { get; init; }

    [XmlArray("nrPmuLicAppobjService")]
    [XmlArrayItem("nrPmuLicAppobjServiceItem")]
    [JsonPropertyName("nrPmuLicAppobjService")]
    public NrPmuLicAppObjService[]? NrPmuLicAppObjService { get; init; }
}
