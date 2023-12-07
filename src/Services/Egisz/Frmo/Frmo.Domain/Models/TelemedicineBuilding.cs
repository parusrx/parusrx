// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
