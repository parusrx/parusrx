// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Domain;

public record HospitalSubdivisionBed
{
    [XmlElement("bedProfileId")]
    [JsonPropertyName("bedProfileId")]
    public HospitalSubdivisionBedProfileId BedProfileId { get; init; } = default!;

    [XmlElement("bedCount")]
    [JsonPropertyName("bedCount")]
    public int BedCount { get; init; }
}
