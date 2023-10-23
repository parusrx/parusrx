// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

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
