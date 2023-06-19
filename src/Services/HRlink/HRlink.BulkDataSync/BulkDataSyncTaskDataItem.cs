// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.BulkDataSync;

public sealed record BulkDataSyncTaskDataItem
{
    public string? Id { get; init; }
    public required string ExternalId { get; init; }
    public required BulkDataSyncTaskDataItemState State { get; init; }
    public BulkDataSyncTaskDataItemResult? Result { get; init; }
    public string? ErrorMessage { get; init; }
    public object? ErrorData { get; init; }
}
