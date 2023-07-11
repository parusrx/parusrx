// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.Internal;

/// <summary>
/// Bulk data sync task.
/// </summary>
/// <param name="Total">The total count.</param>
/// <param name="Processed">The processed count.</param>
/// <param name="Succeeded">The succeeded count.</param>
/// <param name="Failed">The failed count.</param>
public sealed record BulkDataSyncTaskCounts(int? Total, int? Processed, int? Succeeded, int? Failed);