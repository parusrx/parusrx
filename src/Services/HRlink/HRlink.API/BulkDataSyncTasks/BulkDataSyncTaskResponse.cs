// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.API.BulkDataSyncTasks;

/// <summary>
/// Represents a response of a bulk data sync task.
/// </summary>
[XmlRoot("bulkDataSyncTaskResponse")]
public record BulkDataSyncTaskResponse
{
    /// <summary>
    /// Gets or sets the result of the bulk data sync task.
    /// </summary>
    [XmlElement("result")]
    public bool Result { get; init; }

    /// <summary>
    /// Gets or sets the bulk data sync task.
    /// </summary>
    [XmlElement("task")]
    public BulkDataSyncTask? BulkDataSyncTask { get; init; }
}