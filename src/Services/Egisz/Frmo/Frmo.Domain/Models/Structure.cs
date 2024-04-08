// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record Structure
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string Id { get; init; } = default!;

    [XmlElement("parentId")]
    [JsonPropertyName("parentId")]
    public string ParentId { get; init; } = default!;

    [XmlElement("childId")]
    [JsonPropertyName("childId")]
    public string ChildId { get; init; } = default!;

    [XmlElement("relationType")]
    [JsonPropertyName("relationType")]
    public int RelationType { get; init; }
}
