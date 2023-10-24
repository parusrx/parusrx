// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

[XmlRoot("staffRequest")]
public record StaffRequest
{
    [XmlElement("parameters")]
    public required StaffParameters Parameters { get; init; }
}

public record StaffParameters
{
    [XmlElement("oid")]
    public required string Oid { get; init; }
}