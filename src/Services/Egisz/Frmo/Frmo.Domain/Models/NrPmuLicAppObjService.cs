﻿// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Domain;

public record NrPmuLicAppObjService
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [XmlElement("parentId")]
    [JsonPropertyName("parentId")]
    public int? ParentId { get; init; }

    [XmlElement("activityId")]
    [JsonPropertyName("activityId")]
    public int? ActivityId { get; init; }

    [XmlElement("licensedService")]
    [JsonPropertyName("licensedService")]
    public string? LicensedService { get; init; }

    [XmlElement("active")]
    [JsonPropertyName("active")]
    public bool? Active { get; init; }

    [XmlElement("endDate")]
    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }

    [XmlElement("note")]
    [JsonPropertyName("note")]
    public string? Note { get; init; }
}