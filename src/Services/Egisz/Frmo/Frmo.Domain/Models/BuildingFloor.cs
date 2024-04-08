// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record BuildingFloor
{
    [XmlElement("floorId")]
    [JsonPropertyName("floorId")]
    public string FloorId { get; init; } = default!;

    [XmlElement("floor")]
    [JsonPropertyName("floor")]
    public string Floor { get; init; } = default!;

    [XmlArray("rooms")]
    [XmlArrayItem("roomsItem")]
    [JsonPropertyName("rooms")]
    public BuildingFloorRoom[]? Rooms { get; init; }
}
