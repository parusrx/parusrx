// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Models;

/// <summary>
/// Represents a message response.
/// </summary>
public class MgdResponse
{
    /// <summary>
    /// Gets or sets the response body.
    /// </summary>
    [JsonPropertyName("response")]
    public string Response { get; set; }
}
