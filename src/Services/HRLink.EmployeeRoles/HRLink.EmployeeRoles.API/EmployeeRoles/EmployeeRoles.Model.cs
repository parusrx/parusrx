// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRLink.EmployeeRoles.API;

/// <summary>
/// The employee role.
/// </summary>
public class EmployeeRole
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
public class EmployeeRoleItem
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
public class EmployeeRoleItems
{
    /// <summary>
    /// Gets or sets the employee roles.
    /// </summary>
    [XmlElement("employeeRole")]
    public List<EmployeeRoleItem> EmployeeRoles { get; set; } = new();
}

/// <summary>
/// The employee role DTO extensions.
/// </summary>
internal static class EmployeeRoleItemExtensions
{
    /// <summary>
    /// Convert <see cref="EmployeeRole"/> to <see cref="EmployeeRoleItem"/>.
    /// </summary>
    /// <param name="employeeRole">The <see cref="EmployeeRole"/>.</param>
    /// <returns>The <see cref="EmployeeRoleItem"/>.</returns>
    public static EmployeeRoleItem AsEmployeeRoleItem(this EmployeeRole employeeRole)
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
    /// Convert <see cref="IEnumerable{EmployeeRole}"/> to <see cref="EmployeeRoleItems"/>.
    /// </summary>
    /// <param name="employeeRoles">The <see cref="IEnumerable{EmployeeRole}"/>.</param>
    /// <returns>The <see cref="EmployeeRoleItems"/>.</returns>
    public static EmployeeRoleItems AsEmployeeRoleItems(this IEnumerable<EmployeeRole> employeeRoles)
    {
        var employeeRoleItems = new EmployeeRoleItems();
        employeeRoleItems.EmployeeRoles.AddRange(employeeRoles.Select(x => x.AsEmployeeRoleItem()));
        return employeeRoleItems;
    }
}