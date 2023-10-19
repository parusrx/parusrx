// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.API.BulkDataSyncTasks;

/// <summary>
/// Represents a data item in a bulk data sync task.
/// </summary>
/// <param name="Id">The the bulk data sync task identifier.</param>
public sealed record BulkDataSyncTaskItem(string Id);