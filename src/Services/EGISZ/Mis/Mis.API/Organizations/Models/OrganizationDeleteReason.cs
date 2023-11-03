// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mis.API.Organizations;

public record OrganizationDeleteReason
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [XmlElement("deleteReason")]
    [JsonPropertyName("deleteReason")]
    public string? DeleteReason { get; init; }
}
