﻿// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record LicenseStatusId
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [XmlElement("licenseStatus")]
    [JsonPropertyName("licenseStatus")]
    public string? LicenseStatus { get; init; }
}
