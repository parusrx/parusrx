// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

public record DepartmentBuildingFloorRoom
{
    [XmlElement("roomId")]
    [JsonPropertyName("roomId")]
    public string RoomId { get; init; } = default!;

    [XmlElement("room")]
    [JsonPropertyName("room")]
    public string Room { get; init; } = default!;
}
