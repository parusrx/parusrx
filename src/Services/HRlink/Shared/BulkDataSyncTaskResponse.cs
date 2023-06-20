// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.Internal;

/// <summary>
/// Represents a response of a bulk data sync task.
/// </summary>
/// <param name="Result">The result of the bulk data sync task.</param>
/// <param name="BulkDataSyncTask">The bulk data sync task.</param>
internal record BulkDataSyncTaskResponse(bool Result, BulkDataSyncTask BulkDataSyncTask);
