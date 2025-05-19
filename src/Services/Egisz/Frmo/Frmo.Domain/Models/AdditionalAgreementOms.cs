// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;
public record AdditionalAgreementOms
{
    [XmlElement("periodId")]
    [JsonPropertyName("periodId")]
    public string? PeriodId { get; init; }

    [XmlElement("beginDate")]
    [JsonPropertyName("beginDate")]
    public required DateTime BeginDate { get; init; }

    [XmlElement("endDate")]
    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }
}
