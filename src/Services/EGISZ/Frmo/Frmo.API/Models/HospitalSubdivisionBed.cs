﻿// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

public record HospitalSubdivisionBed
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [XmlElement("bedProfileId")]
    [JsonPropertyName("bedProfileId")]
    public HospitalSubdivisionBedProfile BedProfileId { get; init; } = default!;

    [XmlElement("bedCount")]
    [JsonPropertyName("bedCount")]
    public int? BedCount { get; init; }
}