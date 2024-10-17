// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a signing route stage type enumeration.
/// </summary>
public enum SigningRouteStageType
{
    /// <summary>
    /// The signing.
    /// </summary>
    [XmlEnum("SIGNING")]
    SIGNING,

    /// <summary>
    /// The receiving.
    /// </summary>
    [XmlEnum("RECEIVING")]
    RECEIVING
}
