// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRLink.EmployeeRoles.API;

/// <summary>
/// The employee roles response.
/// </summary>
public sealed class EmployeeRolesResponse
{
    /// <summary>
    /// Gets or sets the result.
    /// </summary>
    public bool Result { get; set; }

    /// <summary>
    /// Gets or sets the employee roles.
    /// </summary>
    public IEnumerable<EmployeeRole>? EmployeeRoles { get; set; }
}
