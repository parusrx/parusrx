﻿// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

[XmlRoot("listPagedDepartmentResponse")]
public record ListPagedDepartmentResponse : BaseResponse
{
    [XmlElement("offset")]
    [JsonPropertyName("offset")]
    public int Offset { get; init; }

    [XmlElement("limit")]
    [JsonPropertyName("limit")]
    public int Limit { get; init; }

    [XmlElement("total")]
    [JsonPropertyName("total")]
    public int Total { get; init; }

    [XmlArray("content")]
    [XmlArrayItem("department")]
    [JsonPropertyName("content")]
    public List<Department>? Content { get; init; }
}