// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Domain;

public record NrPmuLicAppObjTypeId
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [XmlElement("appobjType")]
    [JsonPropertyName("appobjType")]
    public string? AppObjType { get; init; }

    [XmlElement("kindId")]
    [JsonPropertyName("kindId")]
    public int? KindId { get; init; }

    [XmlElement("parentId")]
    [JsonPropertyName("parentId")]
    public int? ParentId { get; init; }
}
