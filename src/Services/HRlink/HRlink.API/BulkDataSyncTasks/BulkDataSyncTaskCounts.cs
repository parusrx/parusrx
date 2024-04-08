// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.BulkDataSyncTasks;

/// <summary>
/// Bulk data sync task.
/// </summary>
public sealed record BulkDataSyncTaskCounts
{
    /// <summary>
    /// The total count.
    /// </summary>
    [XmlElement("total")]
    public int? Total { get; init; }

    /// <summary>
    /// The processed count.
    /// </summary>
    [XmlElement("processed")]
    public int? Processed { get; init; }

    /// <summary>
    /// The succeeded count.
    /// </summary>
    [XmlElement("succeeded")]
    public int? Succeeded { get; init; }

    /// <summary>
    /// The failed count.
    /// </summary>
    [XmlElement("failed")]
    public int? Failed { get; init; }
}