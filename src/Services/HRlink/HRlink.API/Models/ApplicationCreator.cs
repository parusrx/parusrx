// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents an application creator in the HRlink system.
/// </summary>
public record ApplicationCreator
{
    /// <summary>
    /// The unique identifier for the application creator.
    /// </summary>
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// The last name.
    /// </summary>
    [XmlElement("lastName")]
    [JsonPropertyName("lastName")]
    public required string LastName { get; init; }

    /// <summary>
    /// The first name.
    /// </summary>
    [XmlElement("firstName")]
    [JsonPropertyName("firstName")]
    public required string FirstName { get; init; }

    /// <summary>
    /// The patronymic (middle name).
    /// </summary>
    [XmlElement("patronymic")]
    [JsonPropertyName("patronymic")]
    public string? Patronymic { get; init; }
}
