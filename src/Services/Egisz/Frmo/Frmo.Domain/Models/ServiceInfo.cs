// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record ServiceInfo
{
    [XmlElement("guid")]
    [JsonPropertyName("guid")]
    public string? Guid { get; init; }

    [XmlElement("activity")]
    [JsonPropertyName("activity")]
    public Activity Activity { get; init; } = default!;

    [XmlArray("services")]
    [XmlArrayItem("servicesItem")]
    [JsonPropertyName("services")]
    public Service[] Services { get; init; } = [];
}
