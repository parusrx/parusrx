// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

public record ShortEntity
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }
    
    [XmlElement("name")]
    [JsonPropertyName("name")]
    public string? Name { get; init; }
}
