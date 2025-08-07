// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.Domain;

public record RowItem
{
    [XmlElement("statisticUnit")]
    [JsonPropertyName("statisticUnit")]
    public int? StatisticUnit { get; init; }

    [XmlElement("service")]
    [JsonPropertyName("service")]
    public Service? Service { get; init; }

    [XmlElement("ksg")]
    [JsonPropertyName("ksg")]
    public Ksg? Ksg { get; init; }

    [XmlElement("vmp")]
    [JsonPropertyName("vmp")]
    public Vmp? Vmp { get; init; }

    [XmlElement("count")]
    [JsonPropertyName("count")]
    public int? Count { get; init; }

    [XmlElement("countExcludedByMek")]
    [JsonPropertyName("countExcludedByMek")]
    public int? CountExcludedByMek { get; init; }

    [XmlElement("countExpertise")]
    [JsonPropertyName("countExpertise")]
    public int? CountExpertise { get; init; }

    [XmlElement("countDefectedByExp")]
    [JsonPropertyName("countDefectedByExp")]
    public int? CountDefectedByExp { get; init; }
}
