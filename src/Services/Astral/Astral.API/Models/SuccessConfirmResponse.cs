﻿// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Astral.API.Models;

public record SuccessConfirmResponse
{
    [XmlElement("status")]
    [JsonPropertyName("status")]
    public required int Status { get; init; }

    [XmlElement("type")]
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [XmlElement("title")]
    [JsonPropertyName("title")]
    public required string Title { get; init; }

    [XmlElement("count")]
    [JsonPropertyName("count")]
    public required int Count { get; init; }
}