// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record EquipmentDepartSubdivision
{
    [XmlElement("subdivisionId")]
    [JsonPropertyName("subdivisionId")]
    public string SubdivisionId { get; init; } = default!;

    [XmlElement("subdivisionName")]
    [JsonPropertyName("subdivisionName")]
    public string? SubdivisionName { get; init; }
}
