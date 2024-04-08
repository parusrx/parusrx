// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.BulkDataSyncTasks;

/// <summary>
/// Represents a response of a bulk data sync task.
/// </summary>
/// <param name="Result">The result of the bulk data sync task.</param>
/// <param name="BulkDataSyncTask">The bulk data sync task.</param>
public sealed record CreateBulkDataSyncTaskResponse(bool Result, BulkDataSyncTaskItem BulkDataSyncTask);