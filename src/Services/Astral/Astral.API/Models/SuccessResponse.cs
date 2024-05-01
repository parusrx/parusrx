// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Astral.API.Models;

public record SuccessResponse
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
}
