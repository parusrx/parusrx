// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

[XmlRoot("frmoListPagedDepartmentRequest")]
public record ListPagedDepartmentRequest
{
    [XmlElement("parameters")]
    public required ListPagedDepartmentParameters Parameters { get; init; }
}

public record ListPagedDepartmentParameters
{
    [XmlElement("departTypeId")]
    public required int DepartTypeId { get; init; }

    [XmlElement("oid")]
    public required string Oid { get; init; }

    [XmlElement("offset")]
    public int Offset { get; init; } = 0;

    [XmlElement("limit")]
    public int Limit { get; init; } = 10;   
}