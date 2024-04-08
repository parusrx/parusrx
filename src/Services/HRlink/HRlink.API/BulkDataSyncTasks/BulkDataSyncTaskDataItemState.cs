// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.BulkDataSyncTasks;

/// <summary>
/// Represents the state of a data item in a bulk data sync task.
/// </summary>
public enum BulkDataSyncTaskDataItemState
{
    /// <summary>
    /// The data item is synced.
    /// </summary>
    [XmlEnum("SYNCED")]
    SYNCED,

    /// <summary>
    /// The data item sync failed.
    /// </summary>
    [XmlEnum("FAILED")]
    FAILED
}