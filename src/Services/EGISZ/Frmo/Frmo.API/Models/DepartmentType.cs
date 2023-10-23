// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

public record DepartmentType
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [XmlElement("departType")]
    [JsonPropertyName("departType")]
    public string? DepartType { get; init; }
}
