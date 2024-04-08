// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a document result item for a create document group response.
/// </summary>
public record DocumentResultItem
{
    /// <summary>
    /// Gets or sets the identifier of the document.
    /// </summary>
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }
}
