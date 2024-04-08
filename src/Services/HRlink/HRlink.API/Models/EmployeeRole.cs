// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents an employee role.
/// </summary>
[XmlRoot("employeeRole")]
public record EmployeeRole
{
    /// <summary>
    /// Gets or sets the identifier of the employee role.
    /// </summary>
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets or sets the name of the employee role.
    /// </summary>
    [XmlElement("name")]
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Gets or sets the description of the employee role.
    /// </summary>
    [XmlElement("description")]
    [JsonPropertyName("description")]
    public string? Description { get; init; }
}