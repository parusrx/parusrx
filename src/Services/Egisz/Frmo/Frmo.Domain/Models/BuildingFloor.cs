﻿// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.Domain.Models;

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
    public BuildingRoom[]? Rooms { get; init; }
}