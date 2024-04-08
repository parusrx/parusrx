// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Models;

/// <summary>
/// Represents a message request.
/// </summary>
[XmlRoot(ElementName = "MgdMessageRequest")]
public class MgdMessageRequest
{
    /// <summary>
    /// Gets or sets the credentials.
    /// </summary>
    [XmlElement(ElementName = "Credential")]
    public Credential Credential { get; set; }
}

/// <summary>
/// Represents a credentials.
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

    /// <summary>
    /// Gets or sets the company identifier.
    /// </summary>
    [XmlElement(ElementName = "CompanyId")]
    public string CompanyId { get; set; }

    /// <summary>
    /// Gets or sets the juridical person identifier.
    /// </summary>
    [XmlElement(ElementName = "JuridicalPersonId")]
    public string JuridicalPersonId { get; set; }
}
