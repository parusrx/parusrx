// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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