// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record TelemedicineCabinet
{
    [XmlElement("code")]
    [JsonPropertyName("code")]
    public string Code { get; init; } = default!;

    [XmlElement("name")]
    [JsonPropertyName("name")]
    public string? Name { get; init; }
}
