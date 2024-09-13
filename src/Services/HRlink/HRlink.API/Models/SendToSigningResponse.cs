// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a send to signing response.
/// </summary>
public record SendToSigningResponse
{
    /// <summary>
    /// Gets or sets the result of the send to signing operation.
    /// </summary>
    [XmlElement("result")]
    [JsonPropertyName("result")]
    public required bool Result { get; init; }

    /// <summary>
    /// Gets or sets the task to send to signing.
    /// </summary>
    [XmlElement("sendToSigningTask")]
    [JsonPropertyName("sendToSigningTask")]
    public required SendToSigningTask Task { get; init; }
}

/// <summary>
/// Represents a send to signing task.
/// </summary>
public record SendToSigningTask
{
    /// <summary>
    /// Gets or sets the document group identifier.
    /// </summary>
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public required string Id { get; init; }
}