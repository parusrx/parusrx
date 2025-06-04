// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

public record EmployeeWithPositionAndDepartment
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [XmlElement("externalId")]
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; init; }

    [XmlElement("position")]
    [JsonPropertyName("position")]
    public ShortEntity? Position { get; init; }

    [XmlElement("department")]
    [JsonPropertyName("department")]
    public ShortEntity? Department { get; init; }
}