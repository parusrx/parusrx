// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

[XmlRoot("updateStaffRequest")]
public record UpdateStaffRequest
{
    [XmlElement("parameters")]
    public required UpdateStaffParameters Parameters { get; init; }

    [XmlElement("content")]
    public required UpdateStaffContent Content { get; init; }
}

public record UpdateStaffParameters
{
    [XmlElement("oid")]
    public required string Oid { get; init; }

    [XmlElement("entityId")]
    public required string EntityId { get; init; }
}

public record UpdateStaffContent
{
    [XmlElement("staff")]
    public required Staff Staff { get; init; }
}