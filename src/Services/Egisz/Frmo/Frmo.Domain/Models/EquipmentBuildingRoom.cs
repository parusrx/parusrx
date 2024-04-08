// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record EquipmentBuildingRoom
{
    [XmlElement("roomId")]
    [JsonPropertyName("roomId")]
    public string RoomId { get; init; } = default!;

    [XmlElement("roomName")]
    [JsonPropertyName("roomName")]
    public string? RoomName { get; init; }
}
