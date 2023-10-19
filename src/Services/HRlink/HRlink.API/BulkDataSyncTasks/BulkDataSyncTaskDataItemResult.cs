// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.API.BulkDataSyncTasks;

/// <summary>
/// Represents the result of a data item in a bulk data sync task.
/// </summary>
public enum BulkDataSyncTaskDataItemResult
{
    /// <summary>
    /// The data item is not modified.
    /// </summary>
    [XmlEnum("NOT_MODIFIED")]
    NOT_MODIFIED,

    /// <summary>
    /// The data item is created.
    /// </summary>
    [XmlEnum("CREATED")]
    CREATED,

    /// <summary>
    /// The data item is updated.
    /// </summary>
    [XmlEnum("UPDATED")]
    UPDATED
}