// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Astral.API.Models;

[XmlRoot("request")]
public record DefaultRequest<TPayload>
{
    [XmlElement("authorization")]
    public required Authorization Authorization { get; init; }

    [XmlElement("payload")]
    public required TPayload Payload { get; init; }
}
