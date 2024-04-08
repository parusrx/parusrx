// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record EquipmentBuildingFloor
{
    [XmlElement("floorId")]
    [JsonPropertyName("floorId")]
    public string FloorId { get; set; } = default!;

    [XmlElement("floorName")]
    [JsonPropertyName("floorName")]
    public string? FloorName { get; set; }

    [XmlArray("buildingRoom")]
    [XmlArrayItem("buildingRoomItem")]
    [JsonPropertyName("buildingRoom")]
    public BuildingFloorRoom[]? BuildingRoom { get; set; }
}
