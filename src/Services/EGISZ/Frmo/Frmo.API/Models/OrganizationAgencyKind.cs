﻿// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

public record OrganizationAgencyKind
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [XmlElement("parentId")]
    [JsonPropertyName("parentId")]
    public int? ParentId { get; init; }

    [XmlElement("agencyKind")]
    [JsonPropertyName("agencyKind")]
    public string? AgencyKind { get; init; }
}