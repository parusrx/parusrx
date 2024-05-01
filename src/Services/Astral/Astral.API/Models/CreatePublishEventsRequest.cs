// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Astral.API.Models;

[XmlRoot("createPublishEventsRequest")]
public record CreatePublishEventsRequest
{
    [XmlElement("authorization")]
    public required Authorization Authorization { get; init; }

    [XmlElement("publishEventsRequest")]
    public required PublishEventsRequest PublishEventsRequest { get; init; }
}
