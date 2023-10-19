// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

[XmlRoot("frmoGetByOidDepartmentRequest")]
public record GetByOidDepartmentRequest
{
    [XmlElement("parameters")]
    public GetByOidDepartmentParameters Parameters { get; init; } = default!;
}

public record GetByOidDepartmentParameters
{
    [XmlElement("departOid")]
    public string DepartOid { get; init; } = default!;

    [XmlElement("oid")]
    public string Oid { get; init; } = default!;
}