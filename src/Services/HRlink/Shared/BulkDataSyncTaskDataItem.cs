// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.Internal;

/// <summary>
/// Represents a data item in a bulk data sync task.
/// </summary>
internal sealed record BulkDataSyncTaskDataItem
{
    /// <summary>
    /// Gets or sets the data item identifier.
    /// </summary>
    public string? Id { get; init; }

    /// <summary>
    /// Gets or sets the data item external identifier.
    /// </summary>
    public required string ExternalId { get; init; }

    /// <summary>
    /// Gets or sets the data item state.
    /// </summary>
    public required BulkDataSyncTaskDataItemState State { get; init; }

    /// <summary>
    /// Gets or sets the data item result.
    /// </summary>
    /// <remarks>
    /// The result is <see cref="BulkDataSyncTaskDataItemResult.NOT_MODIFIED"/> by default.
    /// </remarks>
    public BulkDataSyncTaskDataItemResult? Result { get; init; }

    /// <summary>
    /// Gets or sets the data item error message.
    /// </summary>
    public string? ErrorMessage { get; init; }

    /// <summary>
    /// Gets or sets the data item error data.
    /// </summary>
    public object? ErrorData { get; init; }
}
