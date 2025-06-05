// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

[XmlRoot("getHrRegistryV2Request")]
public record GetHrRegistryV2ApplicationGroupsRequest
{
    [XmlElement("authorization")]
    public required AuthorizationContext Authorization { get; init; }

    [XmlElement("filter")]
    public required ApplicationGroupRegistryV2Filter Filter { get; init; }
}
