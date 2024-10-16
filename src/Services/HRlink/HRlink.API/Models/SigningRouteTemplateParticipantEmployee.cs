// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents an employee participant in a signing route template.
/// </summary>
[XmlRoot("signingRouteTemplateParticipantEmployee")]
public record SigningRouteTemplateParticipantEmployee
{
    /// <summary>
    /// Gets or sets the last name of the employee.
    /// </summary>
    [XmlElement("lastName")]
    [JsonPropertyName("lastName")]
    public string? LastName { get; init; }

    /// <summary>
    /// Gets or sets the first name of the employee.
    /// </summary>
    [XmlElement("firstName")]
    [JsonPropertyName("firstName")]
    public string? FirstName { get; init; }

    /// <summary>
    /// Gets or sets the patronymic of the employee.
    /// </summary>
    [XmlElement("patronymic")]
    [JsonPropertyName("patronymic")]
    public string? Patronymic { get; init; }

    /// <summary>
    /// Gets or sets the identifier of the employee.
    /// </summary>
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets or sets the department of the employee.
    /// </summary>
    [XmlElement("department")]
    [JsonPropertyName("department")]
    public SigningRouteTemplateParticipantEmployeeDepartment? Department { get; init; }

    /// <summary>
    /// Gets or sets the position of the employee.
    /// </summary>
    [XmlElement("position")]
    [JsonPropertyName("position")]
    public SigningRouteTemplateParticipantEmployeePosition? Position { get; init; }
}
