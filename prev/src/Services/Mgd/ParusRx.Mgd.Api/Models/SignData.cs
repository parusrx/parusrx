// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Models;

/// <summary>
/// Represents a signature data.
/// </summary>
public class SignData
{
    /// <summary>
    /// Gets or sets the Base64 encoded content.
    /// </summary>
    [JsonPropertyName("content")]
    public string ContentAsBase64 { get; set; }
}
