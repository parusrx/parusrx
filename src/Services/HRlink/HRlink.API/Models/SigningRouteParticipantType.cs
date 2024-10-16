// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents the type of a participant in a signing route.
/// </summary>
public enum SigningRouteParticipantType
{
    /// <summary>
    /// The participant is an employee.
    /// </summary>
    [XmlEnum("EMPLOYEE")]
    EMPLOYEE,

    /// <summary>
    /// The participant is an employer.
    /// </summary>
    [XmlEnum("EMPLOYER")]
    EMPLOYER,

    /// <summary>
    /// The participant is a fixed employee.
    /// </summary>
    [XmlEnum("FIXED_EMPLOYEE")]
    FIXED_EMPLOYEE,

    /// <summary>
    /// The participant is a selectable employee.
    /// </summary>
    [XmlEnum("SELECTABLE_EMPLOYEE")]
    SELECTABLE_EMPLOYEE,

    /// <summary>
    /// The participant with a specific role.
    /// </summary>
    [XmlEnum("ROLE")]
    ROLE,

    /// <summary>
    /// The participant is a responsible person.
    /// </summary>
    [XmlEnum("RESPONSIBLE")]
    RESPONSIBLE
}
