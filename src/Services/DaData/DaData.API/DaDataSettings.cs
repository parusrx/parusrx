// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DaData.API;

/// <summary>
/// Represents the DaData settings.
/// </summary>
public record DaDataSettings
{
    /// <summary>
    /// Gets or sets the URL of the DaData Suggestions API.
    /// </summary>
    public required string Suggestions { get; init; }
}
