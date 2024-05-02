// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Runtime.Serialization;

using ParusRx.Astral.Domain.Poa;

namespace ParusRx.Astral.API.Models;

[XmlInclude(typeof(PoaCreateUnifiedRequest))]
[XmlInclude(typeof(PoaCreateUnifiedResponse))]
[KnownType(typeof(PoaCreateUnifiedRequest))]
[KnownType(typeof(PoaCreateUnifiedResponse))]
public record EventToPublish
{
    [XmlElement("code")]
    [JsonPropertyName("code")]
    public required string Code { get; init; }

    [XmlElement("parent")]
    [JsonPropertyName("parent")]
    public string? Parent { get; init; }

    [XmlArray("consumers")]
    [XmlArrayItem("consumer")]
    [JsonPropertyName("consumer")]
    public required string[] Consumer { get; init; }

    [XmlElement("data")]
    [JsonPropertyName("data")]
    public required object Data { get; init; }
}
