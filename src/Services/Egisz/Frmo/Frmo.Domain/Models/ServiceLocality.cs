// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.Domain.Models;

public record ServiceLocality
{
    [XmlElement("serviceLocalityId")]
    [JsonPropertyName("serviceLocalityId")]
    public string ServiceLocalityId { get; init; } = default!;

    [XmlElement("localityAddress")]
    [JsonPropertyName("localityAddress")]
    public LocalityAddress LocalityAddress { get; init; } = new();
}
