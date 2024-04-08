// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

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
