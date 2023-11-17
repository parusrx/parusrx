// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

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
