// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Domain;

public record Tpgg
{
    [XmlElement("guid")]
    [JsonPropertyName("guid")]
    public string? Guid { get; init; }

    [XmlElement("year")]
    [JsonPropertyName("year")]
    public int? Year { get; init; }

    [XmlElement("visitCount")]
    [JsonPropertyName("visitCount")]
    public int? VisitCount { get; init; }

    [XmlElement("visitOms")]
    [JsonPropertyName("visitOms")]
    public int? VisitOms { get; init; }
}
