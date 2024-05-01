// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Astral.API.Models;

public record ConfirmEventsRequest
{
    [XmlArray("events_id")]
    [XmlArrayItem("id")]
    [JsonPropertyName("events_id")]
    public required string[] Ids { get; init; }
}
