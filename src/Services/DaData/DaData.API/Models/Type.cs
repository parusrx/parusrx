// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DaData.API.Models;

/// <summary>
/// Represents type.
/// </summary>
public enum Type
{
    /// <summary>
    /// The legal.
    /// </summary>
    [XmlEnum("LEGAL")]
    LEGAL,

    /// <summary>
    /// The individual.
    /// </summary>
    [XmlEnum("INDIVIDUAL")]
    INDIVIDUAL
}
