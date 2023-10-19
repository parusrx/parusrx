// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
