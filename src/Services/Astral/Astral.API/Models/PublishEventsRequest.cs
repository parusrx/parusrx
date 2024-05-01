// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Astral.API.Models;

public record PublishEventsRequest
{
    [XmlArray("events")]
    [XmlArrayItem("event")]
    [JsonPropertyName("events")]
    public required EventToPublish[] Events { get; init; }
}
