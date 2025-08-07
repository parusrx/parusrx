// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.Domain;

public record PeriodDateItem
{
    [XmlElement("periodDate")]
    [JsonPropertyName("periodDate")]
    public DateTime? PeriodDate { get; init; }

    [XmlElement("omsId")]
    [JsonPropertyName("omsId")]
    public string? OmsId { get; init; }

    [XmlArray("rows")]
    [XmlArrayItem("rowsItem")]
    [JsonPropertyName("rows")]
    public RowItem[]? Rows { get; init; }
}
