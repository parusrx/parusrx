﻿// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.Domain;

public record EquipmentType
{
    [XmlElement("code")]
    [JsonPropertyName("code")]
    public int Code { get; set; }

    [XmlElement("name")]
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}