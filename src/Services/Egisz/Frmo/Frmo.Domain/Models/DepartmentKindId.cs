// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.Domain;

public record DepartmentKindId
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [XmlElement("departKind")]
    [JsonPropertyName("departKind")]
    public string? DepartKind { get; init; }
}
