// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record OrganizationAffilation
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [XmlElement("parentId")]
    [JsonPropertyName("parentId")]
    public int ParentId { get; init; }

    [XmlElement("nameFull")]
    [JsonPropertyName("nameFull")]
    public string? NameFull { get; init; }

    [XmlElement("nameShort")]
    [JsonPropertyName("nameShort")]
    public string? NameShort { get; init; }

    [XmlElement("isActive")]
    [JsonPropertyName("isActive")]
    public bool IsActive { get; init; }
}
