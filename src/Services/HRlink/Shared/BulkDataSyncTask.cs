// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace ParusRx.HRlink.Internal;

/// <summary>
/// Represents a bulk data sync task.
/// </summary>
public sealed record BulkDataSyncTask
{
    /// <summary>
    /// Gets or sets the bulk data sync task identifier.
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    /// Gets or sets the bulk data sync task type.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public BulkDataSyncTaskType? Type { get; init; }

    /// <summary>
    /// Gets or sets the bulk data sync task state.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public BulkDataSyncTaskState? State { get; init; }

    /// <summary>
    /// Gets or sets the bulk data sync item counts.
    /// </summary>
    public BulkDataSyncTaskCounts? Counts { get; init; }

    /// <summary>
    /// Gets or sets the bulk data sync task data.
    /// </summary>
    public IEnumerable<BulkDataSyncTaskDataItem>? Data { get; init; }

    /// <summary>
    /// Gets or sets the created date.
    /// </summary>
    public DateTime? CreatedDate { get; init; }
}
