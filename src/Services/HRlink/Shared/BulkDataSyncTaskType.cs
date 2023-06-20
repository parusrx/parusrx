// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.Internal;

/// <summary>
/// Bulk data sync task type.
/// </summary>
internal enum BulkDataSyncTaskType
{
    /// <summary>
    /// The employee positions.
    /// </summary>
    EMPLOYEE_POSITIONS,

    /// <summary>
    /// The client users.
    /// </summary>
    CLIENT_USERS,

    /// <summary>
    /// The legal entities.
    /// </summary>
    LEGAL_ENTITIES,

    /// <summary>
    /// The client departments.
    /// </summary>
    CLIENT_DEPARTMENTS
}
