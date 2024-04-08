// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EArchive.Api.Models;

/// <summary>
/// Represents a user token.
/// </summary>
public class UserToken
{
    /// <summary>
    /// Gets or sets the access token.
    /// </summary>
    [JsonPropertyName("accessToken")]
    public string AccessToken { get; set; }

    /// <summary>
    /// Gets or sets the token type.
    /// </summary>
    [JsonPropertyName("tokenType")]
    public string TokenType { get; set; }

    /// <summary>
    /// Gets or sets whether a password change is required.
    /// </summary>
    [JsonPropertyName("mustChangePassword")]
    public bool IsChangePassword { get; set; }
}
