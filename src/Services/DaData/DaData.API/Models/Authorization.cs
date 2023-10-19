// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DaData.API.Models;

/// <summary>
/// Represents the header of an authorization request to DaData.ru.
/// </summary>
[XmlRoot("Authorization")]
public record Authorization
{
    /// <summary>
    /// Gets or sets of the access token.
    /// </summary>
    [XmlElement("AccessToken")]
    public required string AccessToken { get; init; }
}
