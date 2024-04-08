// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record DepartBuildingFloorRoom
{
    [XmlElement("roomId")]
    [JsonPropertyName("roomId")]
    public string RoomId { get; init; } = default!;

    [XmlElement("room")]
    [JsonPropertyName("room")]
    public string Room { get; init; } = default!;
}
