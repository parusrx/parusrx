// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Astral.API.Models;

public record SuccessConfirmResponse : SuccessResponse
{
    [XmlElement("count")]
    [JsonPropertyName("count")]
    public required int Count { get; init; }
}
