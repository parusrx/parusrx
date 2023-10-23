// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

[XmlRoot("frmoDeleteDepartmentRequest")]
public record DeleteDepartmentRequest
{
    [XmlElement("parameters")]
    public required DeleteDepartmentParameters Parameters { get; init; }
}

public record DeleteDepartmentParameters
{
    [XmlElement("oid")]
    public required string Oid { get; init; }

    [XmlElement("entityId")]
    public required string EntityId { get; init; }
}
