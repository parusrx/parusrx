// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Authorization;

/// <summary>
/// Represents the authorization information for the request.
/// </summary>
public sealed record AuthorizationContext
{
    /// <summary>
    /// The URL of the HRlink instance.
    /// </summary>
    [XmlElement("url")]
    public required string Url { get; init; }

    /// <summary>
    /// The client identifier.
    /// </summary>
    [XmlElement("clientId")]
    public required string ClientId { get; init; }

    /// <summary>
    /// The API token.
    /// </summary>
    [XmlElement("apiToken")]
    public required string ApiToken { get; init; }
}