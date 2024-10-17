// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a signing route stage completeness condition enumeration.
/// </summary>
public enum SigningRouteStageCompletenessCondition
{
    /// <summary>
    /// The all.
    /// </summary>
    [XmlEnum("ALL")]
    ALL,

    /// <summary>
    /// The any.
    /// </summary>
    [XmlEnum("ANY")]
    ANY
}
