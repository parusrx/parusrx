// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record TerritorialDepart
{
    [XmlElement("moTerritorialDepartId")]
    [JsonPropertyName("moTerritorialDepartId")]
    public string? MoTerritorialDepartId { get; init; }

    [XmlElement("moTerritorialDepartName")]
    [JsonPropertyName("moTerritorialDepartName")]
    public string MoTerritorialDepartName { get; init; } = default!;

    [XmlArray("buildings")]
    [XmlArrayItem("buildingsItem")]
    [JsonPropertyName("buildings")]
    public TerritorialDepartBuilding[] Buildings { get; init; } = [];

    [XmlArray("marks")]
    [XmlArrayItem("marksItem")]
    [JsonPropertyName("marks")]
    public Mark[]? Marks { get; init; }
}
