﻿// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.Domain.Models;

public record WorkPeriod
{
    [XmlElement("workDay")]
    [JsonPropertyName("workDay")]
    public string? WorkDay { get; init; }

    [XmlElement("workTimeBegin")]
    [JsonPropertyName("workTimeBegin")]
    public string? WorkTimeBegin { get; init; }

    [XmlElement("workTimeEnd")]
    [JsonPropertyName("workTimeEnd")]
    public string? WorkTimeEnd { get; init; }
}