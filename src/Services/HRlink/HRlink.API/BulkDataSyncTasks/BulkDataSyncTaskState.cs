// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.BulkDataSyncTasks;

/// <summary>
/// Bulk data sync task state.
/// </summary>
public enum BulkDataSyncTaskState
{
    /// <summary>
    /// The task is queued.
    /// </summary>
    [XmlEnum("QUEUED")]
    QUEUED,

    /// <summary>
    /// The task is in progress.
    /// </summary>
    [XmlEnum("IN_PROGRESS")]
    IN_PROGRESS,

    /// <summary>
    /// The task is finished.
    /// </summary>
    [XmlEnum("FINISHED")]
    FINISHED,

    /// <summary>
    /// The task is failed.
    /// </summary>
    [XmlEnum("FAILED")]
    FAILED
}