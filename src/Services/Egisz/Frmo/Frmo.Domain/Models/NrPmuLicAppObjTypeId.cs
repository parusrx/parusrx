// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

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
