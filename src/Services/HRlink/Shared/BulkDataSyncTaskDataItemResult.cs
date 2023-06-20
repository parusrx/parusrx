// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.Internal;

/// <summary>
/// Represents the result of a data item in a bulk data sync task.
/// </summary>
internal enum BulkDataSyncTaskDataItemResult
{
    /// <summary>
    /// The data item is not modified.
    /// </summary>
    NOT_MODIFIED,

    /// <summary>
    /// The data item is created.
    /// </summary>
    CREATED,

    /// <summary>
    /// The data item is updated.
    /// </summary>
    UPDATED
}
