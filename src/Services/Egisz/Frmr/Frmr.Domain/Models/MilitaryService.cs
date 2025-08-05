// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.Domain;

[XmlRoot("militaryService")]
public record MilitaryService
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [XmlElement("militaryService")]
    [JsonPropertyName("militaryService")]
    public bool IsMilitaryService { get; init; }

    [XmlElement("beginDate")]
    [JsonPropertyName("beginDate")]
    public DateTime? BeginDate { get; init; }

    [XmlElement("endDate")]
    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }
}