// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Astral.API.Models;

public sealed record Authorization
{
    [XmlElement("uri")]
    public required string Uri { get; init; }

    [XmlElement("apiKey")]
    public required string ApiKey { get; init; }
}
