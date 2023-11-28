// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Domain;

public record BuildingFloorRoom
{
    [XmlElement("roomId")]
    [JsonPropertyName("roomId")]
    public string? RoomId { get; init; }

    [XmlElement("roomName")]
    [JsonPropertyName("roomName")]
    public string RoomName { get; init; } = default!;

    [XmlElement("roomArea")]
    [JsonPropertyName("roomArea")]
    public double? RoomArea { get; init; }
}
