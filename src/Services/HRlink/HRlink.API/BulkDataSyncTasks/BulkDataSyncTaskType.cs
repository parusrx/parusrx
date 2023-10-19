// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.API.BulkDataSyncTasks;

/// <summary>
/// Bulk data sync task type.
/// </summary>
public enum BulkDataSyncTaskType
{
    /// <summary>
    /// The employee positions.
    /// </summary>
    [XmlEnum("EMPLOYEE_POSITIONS")]
    EMPLOYEE_POSITIONS,

    /// <summary>
    /// The client users.
    /// </summary>
    [XmlEnum("CLIENT_USERS")]
    CLIENT_USERS,

    /// <summary>
    /// The legal entities.
    /// </summary>
    [XmlEnum("LEGAL_ENTITIES")]
    LEGAL_ENTITIES,

    /// <summary>
    /// The client departments.
    /// </summary>
    [XmlEnum("CLIENT_DEPARTMENTS")]
    CLIENT_DEPARTMENTS
}