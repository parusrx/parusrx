// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRLink.EmployeeRoles.API;

/// <summary>
/// The employee roles request.
/// </summary>
[XmlRoot("employeeRolesRequest")]
public sealed class EmployeeRolesRequest
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
