// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents the type of the auto-select participant rule.
/// </summary>
public enum AutoSelectParticipantRuleType
{
    /// <summary>
    /// Autocomplete department head manager.
    /// </summary>
    [XmlEnum("DEPARTMENT_HEAD_MANAGER")]
    DEPARTMENT_HEAD_MANAGER,

    /// <summary>
    /// Autocomplete functional head manager.
    /// </summary>
    [XmlEnum("FUNCTIONAL_HEAD_MANAGER")]
    FUNCTIONAL_HEAD_MANAGER
}
