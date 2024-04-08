// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Models;

/// <summary>
/// Represents a verify data.
/// </summary>
public class VerifyData
{
    /// <summary>
    /// Gets or sets the Base64 encoded content.
    /// </summary>
    [JsonPropertyName("content")]
    public string ContentAsBase64 { get; set; }

    /// <summary>
    /// Gets or sets the Base64 encoded signature.
    /// </summary>
    [JsonPropertyName("signature")]
    public string SignatureAsBase64 { get; set; }
}
