﻿// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.Domain.Models;

public record BrigadeSpecialization
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [XmlElement("brigadeSpec")]
    [JsonPropertyName("brigadeSpec")]
    public string? BrigadeSpec { get; init; }
}