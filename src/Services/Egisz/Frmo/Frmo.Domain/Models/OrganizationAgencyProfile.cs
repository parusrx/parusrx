// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record OrganizationAgencyProfile
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    [XmlElement("parentId")]
    [JsonPropertyName("parentId")]
    public int? ParentId { get; init; }

    [XmlElement("agencyKind")]
    [JsonPropertyName("agencyKind")]
    public string? AgencyKind { get; init; }
}
