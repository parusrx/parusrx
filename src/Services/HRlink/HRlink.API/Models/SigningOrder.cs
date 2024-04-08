// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a signing order value enumeration.
/// </summary>
public enum SigningOrder
{
    /// <summary>
    /// The manager first.
    /// </summary>
    [XmlEnum("MANAGER_FIRST")]
    MANAGER_FIRST,

    /// <summary>
    /// The employee first.
    /// </summary>
    [XmlEnum("EMPLOYEE_FIRST")]
    EMPLOYEE_FIRST,

    /// <summary>
    /// The employee only.
    /// </summary>
    [XmlEnum("EMPLOYEE_ONLY")]
    EMPLOYEE_ONLY,

    /// <summary>
    /// The manager only.
    /// </summary>
    [XmlEnum("MANAGER_ONLY")]
    MANAGER_ONLY,

    /// <summary>
    /// The route.
    /// </summary>
    [XmlEnum("ROUTE")]
    ROUTE
}
