// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace ParusRx.Egisz.Common;

[XmlRoot("response")]
public record ListResponse<TContent> : DefaultResponse
{
    [XmlArray("content")]
    [XmlArrayItem("contentItem")]
    [JsonPropertyName("content")]
    public List<TContent> Content { get; init; } = [];
}
