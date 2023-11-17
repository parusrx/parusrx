// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.DataContracts;

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
