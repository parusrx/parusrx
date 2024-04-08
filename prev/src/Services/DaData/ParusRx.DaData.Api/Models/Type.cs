// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DaData.Api.Models;

/// <summary>
/// Specified type.
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
