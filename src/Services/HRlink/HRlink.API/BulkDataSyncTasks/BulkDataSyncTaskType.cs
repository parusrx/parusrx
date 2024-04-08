// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

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