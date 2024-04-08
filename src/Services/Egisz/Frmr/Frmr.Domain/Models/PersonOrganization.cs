// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.Domain;

public record PersonOrganization
{
    [XmlElement("organizationId")]
    [JsonPropertyName("organizationId")]
    public int OrganizationId { get; init; }

    [XmlElement("beginDate")]
    [JsonPropertyName("beginDate")]
    public DateTime BeginDate { get; init; }

    [XmlElement("endDate")]
    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }

    [XmlElement("entityId")]
    [JsonPropertyName("entityId")]
    public string? EntityId { get; init; }
}
