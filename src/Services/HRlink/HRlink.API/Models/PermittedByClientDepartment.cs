// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents the permission configuration for a client's department.
/// </summary>
public record PermittedByClientDepartment
{
    /// <summary>
    /// The identifier of the client department.
    /// </summary>
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// A value hat indicates whether descendant departments inherit the permission from the client department.
    /// </summary>
    [XmlElement("inheritByDescendantDepartments")]
    [JsonPropertyName("inheritByDescendantDepartments")]
    public required bool InheritByDescendantDepartments { get; init; }
}
