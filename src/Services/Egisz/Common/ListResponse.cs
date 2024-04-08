// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

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
