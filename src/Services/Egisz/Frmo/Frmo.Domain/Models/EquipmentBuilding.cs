// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record EquipmentBuilding
{
    [XmlElement("buildingId")]
    [JsonPropertyName("buildingId")]
    public string BuildingId { get; set; } = default!;

    [XmlElement("buildingName")]
    [JsonPropertyName("buildingName")]
    public string? BuildingName { get; set; }

    [XmlArray("floor")]
    [XmlArrayItem("floorItem")]
    [JsonPropertyName("floor")]
    public EquipmentBuildingFloor[]? Floor { get; set; }
}
