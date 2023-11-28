// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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