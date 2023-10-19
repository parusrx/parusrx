// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents an employee position item.
/// </summary>
/// <remarks>
/// This is used for the bulk data sync.
/// </remarks>
[XmlRoot("employeePositionItem")]
public record EmployeePositionItem
{
    /// <summary>
    /// Gets or sets the external identifier of the employee position.
    /// </summary>
    [XmlElement("externalId")]
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; init; }

    /// <summary>
    /// Gets or sets the name of the employee position.
    /// </summary>
    [XmlElement("name")]
    [JsonPropertyName("name")]
    public string? Name { get; init; }
}