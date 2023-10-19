// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.API.BulkDataSyncTasks;

/// <summary>
/// Represents a response of a bulk data sync task.
/// </summary>
/// <param name="Result">The result of the bulk data sync task.</param>
/// <param name="BulkDataSyncTask">The bulk data sync task.</param>
public sealed record CreateBulkDataSyncTaskResponse(bool Result, BulkDataSyncTaskItem BulkDataSyncTask);