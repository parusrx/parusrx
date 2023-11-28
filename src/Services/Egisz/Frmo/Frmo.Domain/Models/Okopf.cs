// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Domain;

public record Okopf
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [XmlElement("parentId")]
    [JsonPropertyName("parentId")]
    public int? ParentId { get; init; }

    [XmlElement("okopfCode")]
    [JsonPropertyName("okopfCode")]
    public string OkopfCode { get; init; } = default!;

    [XmlElement("okopfName")]
    [JsonPropertyName("okopfName")]
    public string? OkopfName { get; init; }
}
