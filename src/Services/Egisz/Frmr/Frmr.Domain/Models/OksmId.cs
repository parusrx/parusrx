﻿// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.Domain;

public record OksmId
{
    [XmlElement("code")]
    [JsonPropertyName("code")]
    public int Code { get; init; }

    [XmlElement("name")]
    [JsonPropertyName("name")]
    public string? Name { get; init; }
}