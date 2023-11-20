// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace ParusRx.Egisz.Common;

[XmlRoot("response")]
public record ListPagedResponse<TContent> : DefaultResponse
{
    [XmlElement("offset")]
    [JsonPropertyName("offset")]
    public int Offset { get; init; } = 0;

    [XmlElement("limit")]
    [JsonPropertyName("limit")]
    public int Limit { get; init; } = 10;

    [XmlElement("total")]
    [JsonPropertyName("total")]
    public int Total { get; init; }

    [XmlArray("content")]
    [XmlArrayItem("contentItem")]
    [JsonPropertyName("content")]
    public List<TContent> Content { get; init; } = [];
}