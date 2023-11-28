// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
