// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.Domain;

public record Land
{
    [XmlElement("landId")]
    [JsonPropertyName("landId")]
    public string? LandId { get; init; }

    [XmlElement("landName")]
    [JsonPropertyName("landName")]
    public string? LandName { get; init; }

    [XmlElement("landArea")]
    [JsonPropertyName("landArea")]
    public double? LandArea { get; init; }
}
