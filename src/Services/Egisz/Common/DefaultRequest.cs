// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Xml.Serialization;
using ParusRx.Xml;

namespace ParusRx.Egisz.Common;

[XmlRoot("request")]
public record DefaultRequest
{
    [XmlElement("parameters")]
    public required SerializableDictionary Parameters { get; init; }
}

[XmlRoot("request")]
public record DefaultRequest<TContent> : DefaultRequest
{
    [XmlElement("content")]
    public required TContent Content { get; init; }
}