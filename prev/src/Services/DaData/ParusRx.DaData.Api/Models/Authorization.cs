// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DaData.Api.Models;

/// <summary>
/// Represents the header of an authorization request to DaData.ru.
/// </summary>
[XmlRoot("Authorization")]
public class Authorization
{
    /// <summary>
    /// Gets or sets of the access token.
    /// </summary>
    [XmlElement(ElementName = "AccessToken")]
    public string? AccessToken { get; set; }
}
