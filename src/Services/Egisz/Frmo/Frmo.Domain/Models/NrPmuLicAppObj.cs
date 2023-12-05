// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
