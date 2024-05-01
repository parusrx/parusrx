// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Astral.API.Models;

public record EventToPublish
{
    [XmlElement("code")]
    [JsonPropertyName("code")]
    public required string Code { get; init; }

    [XmlElement("parent")]
    [JsonPropertyName("parent")]
    public string? Parent { get; init; }

    [XmlArray("consumers")]
    [XmlArrayItem("consumer")]
    [JsonPropertyName("consumer")]
    public required string[] Consumer { get; init; }

    [XmlElement("data")]
    [JsonPropertyName("data")]
    public required object Data { get; init; }
}
