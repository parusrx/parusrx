// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record ServiceLocality
{
    [XmlElement("serviceLocalityId")]
    [JsonPropertyName("serviceLocalityId")]
    public string ServiceLocalityId { get; init; } = default!;

    [XmlElement("localityAddress")]
    [JsonPropertyName("localityAddress")]
    public LocalityAddress LocalityAddress { get; init; } = new();
}
