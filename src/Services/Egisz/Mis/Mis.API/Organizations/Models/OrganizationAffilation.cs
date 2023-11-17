// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mis.API.Organizations;

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
