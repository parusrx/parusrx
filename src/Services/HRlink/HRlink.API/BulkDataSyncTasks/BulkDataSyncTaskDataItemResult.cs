// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

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