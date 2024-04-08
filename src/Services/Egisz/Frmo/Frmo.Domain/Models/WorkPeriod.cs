// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record WorkPeriod
{
    [XmlElement("workDay")]
    [JsonPropertyName("workDay")]
    public string WorkDay { get; init; } = default!;

    [XmlElement("workTimeBegin")]
    [JsonPropertyName("workTimeBegin")]
    public string WorkTimeBegin { get; init; } = default!;

    [XmlElement("workTimeEnd")]
    [JsonPropertyName("workTimeEnd")]
    public string WorkTimeEnd { get; init; } = default!;
}
