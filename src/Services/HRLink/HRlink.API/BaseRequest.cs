// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRLink.API;

/// <summary>
/// Represents the base request.
/// </summary>
public abstract class BaseRequest
{
    /// <summary>
    /// Gets or sets the URL.
    /// </summary>
    [XmlElement(ElementName = "url")]
    public required string Url { get; set; }

    /// <summary>
    /// Gets or sets the API token.
    /// </summary>
    [XmlElement(ElementName = "apiToken")]
    public required string ApiToken { get; set; }
}