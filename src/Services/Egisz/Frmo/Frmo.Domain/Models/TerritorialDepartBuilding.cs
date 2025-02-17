﻿// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record TerritorialDepartBuilding
{
    [XmlElement("buildingId")]
    [JsonPropertyName("buildingId")]
    public string BuildingId { get; init; } = default!;

    [XmlElement("buildingName")]
    [JsonPropertyName("buildingName")]
    public string? BuildingName { get; init; }
}