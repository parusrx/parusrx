// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a signing object type enumeration.
/// </summary>
public enum SigningObjectType
{
    /// <summary>
    /// The document.
    /// </summary>
    [XmlEnum("DOCUMENT")]
    DOCUMENT,

    /// <summary>
    /// The application.
    /// </summary>
    [XmlEnum("APPLICATION")]
    APPLICATION
}
