// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.DataContracts;

public abstract record BaseRequest
{
    [XmlElement("parameters")]
    public required SerializableDictionary Parameters { get; init; }
}
