﻿// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mis.API.Organizations;

public record Region
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [XmlElement("region")]
    [JsonPropertyName("region")]
    public string? Subject { get; init; }

    [XmlElement("territoryCode")]
    [JsonPropertyName("territoryCode")]
    public int TerritoryCode { get; init; } = default!;

    [XmlElement("isFederalCity")]
    [JsonPropertyName("isFederalCity")]
    public bool IsFederalCity { get; init; }
}