// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record TelemedicineBuilding
{
    [XmlElement("buildingId")]
    [JsonPropertyName("buildingId")]
    public string BuildingId { get; init; } = default!;

    [XmlElement("buildingName")]
    [JsonPropertyName("buildingName")]
    public string? BuildingName { get; init; }

    [XmlArray("floors")]
    [XmlArrayItem("floorsItem")]
    [JsonPropertyName("floors")]
    public TelemedicineFloor[]? Floors { get; init; }

    [XmlArray("rooms")]
    [XmlArrayItem("roomsItem")]
    [JsonPropertyName("rooms")]
    public TelemedicineRoom[]? Rooms { get; init; }
}
