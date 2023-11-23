// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.Domain;

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
