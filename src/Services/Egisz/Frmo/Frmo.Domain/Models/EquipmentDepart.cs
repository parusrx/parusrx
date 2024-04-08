// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

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
