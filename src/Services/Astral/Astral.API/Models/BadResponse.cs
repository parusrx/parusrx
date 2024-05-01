// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Astral.API.Models;

public record BadResponse
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

    [XmlElement("id")]
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [XmlElement("code")]
    [JsonPropertyName("code")]
    public required string Code { get; init; }

    [XmlElement("created")]
    [JsonPropertyName("created")]
    public required DateTime Created { get; init; }

    [XmlElement("detail")]
    [JsonPropertyName("detail")]
    public string? Detail { get; init; }
}
