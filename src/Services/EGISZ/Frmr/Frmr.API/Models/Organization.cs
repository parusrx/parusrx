// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API;

public record Organization
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
