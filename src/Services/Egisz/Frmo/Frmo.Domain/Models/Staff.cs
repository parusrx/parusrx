// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record Staff
{
    [XmlElement("staffId")]
    [JsonPropertyName("staffId")]
    public string? StaffId { get; init; }

    [XmlElement("staffNum")]
    [JsonPropertyName("staffNum")]
    public string StaffNum { get; init; } = default!;

    [XmlElement("staffCreateDate")]
    [JsonPropertyName("staffCreateDate")]
    public DateTime StaffCreateDate { get; init; }

    [XmlElement("beginDate")]
    [JsonPropertyName("beginDate")]
    public DateTime BeginDate { get; init; }

    [XmlElement("endDate")]
    [JsonPropertyName("endDate")]
    public DateTime EndDate { get; init; }

    [XmlArray("staffDetails")]
    [XmlArrayItem("staffDetailsItem")]
    [JsonPropertyName("staffDetails")]
    public StaffDetail[]? StaffDetails { get; init; }
}
