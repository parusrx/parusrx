// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EArchive.Api.Models;

/// <summary>
/// Represents credentials.
/// </summary>
[XmlRoot(ElementName = "Credential")]
public class Credential
{
    /// <summary>
    /// Gets or sets the username.
    /// </summary>
    [XmlElement(ElementName = "Username")]
    public string Username { get; set; }

    /// <summary>
    /// Gets or sets the password.
    /// </summary>
    [XmlElement(ElementName = "Password")]
    public string Password { get; set; }
}
