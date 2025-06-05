// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

public record ApplicationEventDateShortInfo
{
    [XmlElement("label")]
    [JsonPropertyName("label")]
    public string? Label { get; init; }

    [XmlElement("value")]
    [JsonPropertyName("value")]
    public string? Value { get; init; }
}
