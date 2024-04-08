// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DaData.Api.Models;

/// <summary>
/// Specified branch type. 
/// </summary>
public enum BranchType
{
    /// <summary>
    /// The main.
    /// </summary>
    [XmlEnum("MAIN")]
    MAIN,

    /// <summary>
    /// The branch.
    /// </summary>
    [XmlEnum("BRANCH")]
    BRANCH
}
