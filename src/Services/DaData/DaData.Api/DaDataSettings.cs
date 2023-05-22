// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DaData.Api;

/// <summary>
/// Represents the DaData settings.
/// </summary>
public class DaDataSettings
{
    /// <summary>
    /// Gets or sets the URL of the DaData Suggestions API.
    /// </summary>
    public required string Suggestions { get; set; }
}