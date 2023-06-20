// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.Internal;

/// <summary>
/// Represents the state of a data item in a bulk data sync task.
/// </summary>
internal enum BulkDataSyncTaskDataItemState
{
    /// <summary>
    /// The data item is synced.
    /// </summary>
    SYNCED,

    /// <summary>
    /// The data item sync failed.
    /// </summary>
    FAILED
}
