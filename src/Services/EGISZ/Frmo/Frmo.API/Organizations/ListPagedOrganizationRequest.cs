// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

[XmlRoot("frmoListPagedOrganizationRequest")]
public record ListPagedOrganizationRequest
{
    [XmlElement("parameters")]
    public required ListPagedOrganizationParameters Parameters { get; init; }
}

public record ListPagedOrganizationParameters
{
    [XmlElement("orgTypeId")]
    public required int OrgTypeId { get; init; }

    [XmlElement("offset")]
    public required int Offset { get; init; } = 0;

    [XmlElement("limit")]
    public required int Limit { get; init; } = 10;
}