// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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