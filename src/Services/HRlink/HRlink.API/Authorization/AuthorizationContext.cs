// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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