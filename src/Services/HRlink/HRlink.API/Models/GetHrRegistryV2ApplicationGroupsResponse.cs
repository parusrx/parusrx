// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

public record GetHrRegistryV2ApplicationGroupsResponse
{
    [XmlElement("result")]
    [JsonPropertyName("result")]
    public required bool Result { get; init; }

    [XmlArray("applicationGroups")]
    [XmlArrayItem("applicationGroupsItem")]
    [JsonPropertyName("applicationGroups")]
    public required ApplicationGroupWithSigningRoute[] ApplicationGroups { get; init; } = [];
}
