// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents an error details.
/// </summary>
public record ErrorDetails
{
    /// <summary>
    /// Gets or sets the result of the operation.
    /// </summary>
    [JsonPropertyName("result")]
    public bool? Result { get; init; }

    /// <summary>
    /// Gets or sets the error identifier.
    /// </summary>
    [JsonPropertyName("errorId")]
    public string? ErrorId { get; init; }

    /// <summary>
    /// Gets or sets the error message.
    /// </summary>
    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; init; }

    /// <summary>
    /// Gets or sets the error code.
    /// </summary>
    [JsonPropertyName("errorCode")]
    public string? ErrorCode { get; init; }

    /// <summary>
    /// Gets or sets the operation code.
    /// </summary>
    [JsonPropertyName("operationCode")]
    public string? OperationCode { get; init; }

    /// <summary>
    /// Gets or sets the error data.
    /// </summary>
    [JsonPropertyName("errorData")]
    public Dictionary<string, object>? ErrorData { get; init; }
}
