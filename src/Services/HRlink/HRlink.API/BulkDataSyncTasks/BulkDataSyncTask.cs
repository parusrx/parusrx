// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

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