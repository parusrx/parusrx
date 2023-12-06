// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
