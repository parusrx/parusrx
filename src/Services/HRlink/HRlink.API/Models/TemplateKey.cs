// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a template key enumeration.
/// </summary>
public enum TemplateKey
{
    /// <summary>
    /// The approver and HR.
    /// </summary>
    [XmlEnum("APPROVER_AND_HR")]
    APPROVER_AND_HR,

    /// <summary>
    /// The only HR.
    /// </summary>
    [XmlEnum("ONLY_HR")]
    ONLY_HR,

    /// <summary>
    /// The two HR and approver.
    /// </summary>
    [XmlEnum("TWO_HR_AND_APPROVER")]
    TWO_HR_AND_APPROVER,

    /// <summary>
    /// The two approver and HR.
    /// </summary>
    [XmlEnum("TWO_APPROVER_AND_HR ")]
    TWO_APPROVER_AND_HR
}
