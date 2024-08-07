﻿// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record HouseGround
{
    [XmlElement("houseGroundId")]
    [JsonPropertyName("houseGroundId")]
    public string? HouseGroundId { get; init; }

    [XmlElement("houseGround")]
    [JsonPropertyName("houseGround")]
    public string HouseGroundName { get; init; } = default!;

    [XmlElement("contactPerson")]
    [JsonPropertyName("contactPerson")]
    public string? ContactPerson { get; init; }

    [XmlElement("contactPhone")]
    [JsonPropertyName("contactPhone")]
    public string ContactPhone { get; init; } = default!;

    [XmlElement("houseGroundAddress")]
    [JsonPropertyName("houseGroundAddress")]
    public HouseGroundAddress HouseGroundAddress { get; init; } = default!;
}
