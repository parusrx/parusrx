// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record BrigadeSpecId
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [XmlElement("brigadeSpec")]
    [JsonPropertyName("brigadeSpec")]
    public string? BrigadeSpec { get; init; }
}
