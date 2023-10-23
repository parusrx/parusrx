// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

[XmlRoot("deleteStaffRequest")]
public record DeleteStaffRequest
{
    [XmlElement("parameters")]
    public required DeleteStaffParameters Parameters { get; init; }
}

public record DeleteStaffParameters
{
    [XmlElement("oid")]
    public required string Oid { get; init; }

    [XmlElement("entityId")]
    public required string EntityId { get; init; }
}
