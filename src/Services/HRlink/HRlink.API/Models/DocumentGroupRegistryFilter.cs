// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a document group registry filter.
/// </summary>
public record DocumentGroupRegistryFilter
{
    /// <summary>
    /// Gets or sets the list of document IDs in the external system.
    /// </summary>
    [JsonPropertyName("documentExternalIds")]
    public string[]? DocumentExternalIds { get; init; }

    /// <summary>
    /// Gets or sets the limit of the number of documents to return.
    /// </summary>
    public int Limit { get; init; } = 50;
}
