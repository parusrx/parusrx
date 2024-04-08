// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record Region
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [XmlElement("region")]
    [JsonPropertyName("region")]
    public string? Subject { get; init; }

    [XmlElement("territoryCode")]
    [JsonPropertyName("territoryCode")]
    public int TerritoryCode { get; init; } = default!;

    [XmlElement("isFederalCity")]
    [JsonPropertyName("isFederalCity")]
    public bool IsFederalCity { get; init; }
}
