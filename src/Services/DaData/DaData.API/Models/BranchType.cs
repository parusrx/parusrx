// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DaData.API.Models;

/// <summary>
/// Represents branch type.
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
