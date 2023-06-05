// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRLink.EmployeeRole.API;

/// <summary>
/// The employee role.
/// </summary>
public class EmployeeRoleItem
{
    /// <summary>
    /// Gets or sets the employee role identifier.
    /// </summary>
    public string Id { get; set; } = default!;

    /// <summary>
    /// Gets or sets the employee role name.
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Gets or sets the employee role description.
    /// </summary>
    public string Description { get; set; } = default!;
}

/// <summary>
/// The employee role DTO.
/// </summary>
public class EmployeeRoleDto
{
    /// <summary>
    /// Gets or sets the employee role identifier.
    /// </summary>
    [XmlAttribute("id")]
    public string Id { get; set; } = default!;

    /// <summary>
    /// Gets or sets the employee role name.
    /// </summary>
    [XmlAttribute("name")]
    public string Name { get; set; } = default!;

    /// <summary>
    /// Gets or sets the employee role description.
    /// </summary>
    [XmlAttribute("description")]
    public string Description { get; set; } = default!;
}

/// <summary>
/// The employee roles DTO.
/// </summary>
[XmlRoot("employeeRoles")]
public class EmployeeRolesDto
{
    /// <summary>
    /// Gets or sets the employee roles.
    /// </summary>
    [XmlElement("employeeRole")]
    public List<EmployeeRoleDto> EmployeeRoles { get; set; } = new();
}

/// <summary>
/// The employee role DTO extensions.
/// </summary>
internal static class EmployeeRoleItemExtensions
{
    /// <summary>
    /// Convert <see cref="EmployeeRoleItem"/> to <see cref="EmployeeRoleDto"/>.
    /// </summary>
    /// <param name="employeeRole">The <see cref="EmployeeRoleItem"/>.</param>
    /// <returns>The <see cref="EmployeeRoleDto"/>.</returns>
    public static EmployeeRoleDto AsEmployeeRoleItem(this EmployeeRoleItem employeeRole)
        => new()
        {
            Id = employeeRole.Id,
            Name = employeeRole.Name,
            Description = employeeRole.Description
        };
}

/// <summary>
/// The employee roles DTO extensions.
/// </summary>
internal static class EmployeeRoleItemsExtensions
{
    /// <summary>
    /// Convert <see cref="IEnumerable{EmployeeRole}"/> to <see cref="EmployeeRolesDto"/>.
    /// </summary>
    /// <param name="employeeRoles">The <see cref="IEnumerable{EmployeeRole}"/>.</param>
    /// <returns>The <see cref="EmployeeRolesDto"/>.</returns>
    public static EmployeeRolesDto AsEmployeeRolesDto(this IEnumerable<EmployeeRoleItem> employeeRoles)
    {
        var employeeRoleItems = new EmployeeRolesDto();
        employeeRoleItems.EmployeeRoles.AddRange(employeeRoles.Select(x => x.AsEmployeeRoleItem()));
        return employeeRoleItems;
    }
}