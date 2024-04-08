// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace System.Net.Http;

/// <summary>
/// Response message.
/// </summary>
internal class ResponseMessage
{
    /// <summary>
    /// Gets or sets the response message.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; }
}
