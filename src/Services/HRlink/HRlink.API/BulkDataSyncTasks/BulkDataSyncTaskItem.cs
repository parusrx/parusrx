// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.BulkDataSyncTasks;

/// <summary>
/// Represents a data item in a bulk data sync task.
/// </summary>
/// <param name="Id">The the bulk data sync task identifier.</param>
public sealed record BulkDataSyncTaskItem(string Id);