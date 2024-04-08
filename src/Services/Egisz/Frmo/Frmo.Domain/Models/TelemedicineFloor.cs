// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record TelemedicineFloor
{
    [XmlElement("floorId")]
    [JsonPropertyName("floorId")]
    public string FloorId { get; init; } = default!;

    [XmlElement("floorName")]
    [JsonPropertyName("floorName")]
    public string FloorName { get; init; } = default!;
}
