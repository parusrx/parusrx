// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

[XmlRoot("stacSublevel")]
public record StacSublevel
{
    [XmlElement("sublevelId")]
    [JsonPropertyName("sublevelId")]
    public string? SublevelId { get; init; }

    [XmlElement("sublevel")]
    [JsonPropertyName("sublevel")]
    public required string Sublevel { get; init; }

    [XmlElement("beginDate")]
    [JsonPropertyName("beginDate")]
    public required DateTime BeginDate { get; init; }

    [XmlElement("endDate")]
    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }
}
