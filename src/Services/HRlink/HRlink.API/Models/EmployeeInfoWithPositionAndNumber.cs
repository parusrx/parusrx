// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

public record EmployeeInfoWithPositionAndNumber
{
    [XmlElement("lastName")]
    [JsonPropertyName("lastName")]
    public string? LastName { get; init; }

    [XmlElement("firstName")]
    [JsonPropertyName("firstName")]
    public string? FirstName { get; init; }

    [XmlElement("patronymic")]
    [JsonPropertyName("patronymic")]
    public string? Patronymic { get; init; }

    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [XmlElement("position")]
    [JsonPropertyName("position")]
    public ShortEntity? Position { get; init; }

    [XmlElement("number")]
    [JsonPropertyName("number")]
    public string? Number { get; init; }
}