// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.Internal;

/// <summary>
/// Bulk data sync task state.
/// </summary>
internal enum BulkDataSyncTaskState
{
    /// <summary>
    /// The task is queued.
    /// </summary>
    QUEUED,

    /// <summary>
    /// The task is in progress.
    /// </summary>
    IN_PROGRESS,

    /// <summary>
    /// The task is finished.
    /// </summary>
    FINISHED,

    /// <summary>
    /// The task is failed.
    /// </summary>
    FAILED
}
