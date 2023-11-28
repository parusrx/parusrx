// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Domain;

public record EquipmentDepart
{
    [XmlElement("departId")]
    [JsonPropertyName("departId")]
    public string DepartId { get; init; } = default!;

    [XmlElement("departName")]
    [JsonPropertyName("departName")]
    public string? DepartName { get; init; }

    [XmlArray("subdivision")]
    [XmlArrayItem("subdivisionItem")]
    [JsonPropertyName("subdivision")]
    public EquipmentDepartSubdivision[]? Subdivision { get; init; }

    [XmlArray("room")]
    [XmlArrayItem("roomItem")]
    [JsonPropertyName("room")]
    public EquipmentDepartRoom[]? Room { get; init; }
}
