// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents the fill type of the application template field.
/// </summary>
public enum ApplicationTypeTemplateFieldInputType
{
    /// <summary>
    /// Manual input type.
    /// </summary>
    [XmlEnum("MANUAL")]
    MANUAL,

    /// <summary>
    /// Automatic input type.
    /// </summary>
    [XmlEnum("CALCULATED")]
    CALCULATED
}
