// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Domain;

public record TelemedicineFloor
{
    [XmlElement("floorId")]
    [JsonPropertyName("floorId")]
    public string FloorId { get; init; } = default!;

    [XmlElement("floorName")]
    [JsonPropertyName("floorName")]
    public string FloorName { get; init; } = default!;
}
