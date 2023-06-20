// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.Internal;

internal sealed record BulkDataSyncTask
{
    public required string Id { get; init; }
    public BulkDataSyncTaskType? Type { get; init; }
    public BulkDataSyncTaskState? State { get; init; }
    public BulkDataSyncTaskCounts? Counts { get; init; }
    public IEnumerable<BulkDataSyncTaskDataItem>? Data { get; init; }
    public DateTime? CreatedDate { get; init; }
}
