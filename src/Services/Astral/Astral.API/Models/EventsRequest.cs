// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Astral.API.Models;

public record EventsRequest
{
    [XmlElement("timeout")]
    public required int Timeout { get; init; }


    [XmlElement("limit")]
    public required int Limit { get; init; }
}
