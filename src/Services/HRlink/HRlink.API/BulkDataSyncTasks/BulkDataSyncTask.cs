// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.API.BulkDataSyncTasks;

/// <summary>
/// Represents a bulk data sync task.
/// </summary>
public sealed record BulkDataSyncTask
{
    /// <summary>
    /// Gets or sets the bulk data sync task identifier.
    /// </summary>
    [XmlElement("id")]
    public required string Id { get; init; }

    /// <summary>
    /// Gets or sets the bulk data sync task type.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    [XmlElement("type")]
    public BulkDataSyncTaskType? Type { get; init; }

    /// <summary>
    /// Gets or sets the bulk data sync task state.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    [XmlElement("state")]
    public BulkDataSyncTaskState? State { get; init; }

    /// <summary>
    /// Gets or sets the bulk data sync item counts.
    /// </summary>
    [XmlElement("counts")]
    public BulkDataSyncTaskCounts? Counts { get; init; }

    /// <summary>
    /// Gets or sets the bulk data sync task data.
    /// </summary>
    [XmlElement("data")]
    public List<BulkDataSyncTaskDataItem>? Data { get; init; }

    /// <summary>
    /// Gets or sets the created date.
    /// </summary>
    [XmlElement("createdDate")]
    public DateTime? CreatedDate { get; init; }
}