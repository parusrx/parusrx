// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

[XmlRoot("frmoDeleteOrganizationRequest")]
public record DeleteOrganizationRequest
{
    [XmlElement("parameters")]
    public required DeleteOrganizationParameters Parameters { get; init; }
}

public record DeleteOrganizationParameters
{
    [XmlElement("oid")]
    public required string Oid { get; init; }
    [XmlElement("deleteReason")]
    public required int DeleteReason { get; init; }
}
