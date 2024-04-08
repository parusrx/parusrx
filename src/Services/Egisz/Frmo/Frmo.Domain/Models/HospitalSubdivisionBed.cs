// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

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
