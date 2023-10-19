// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.API.BulkDataSyncTasks;

/// <summary>
/// Represents a data item in a bulk data sync task.
/// </summary>
public sealed record BulkDataSyncTaskDataItem
{
    /// <summary>
    /// Gets or sets the data item identifier.
    /// </summary>
    [XmlElement("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets or sets the data item external identifier.
    /// </summary>
    [XmlElement("externalId")]
    public required string ExternalId { get; init; }

    /// <summary>
    /// Gets or sets the data item state.
    /// </summary>
    [XmlElement("state")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required BulkDataSyncTaskDataItemState State { get; init; }

    /// <summary>
    /// Gets or sets the data item result.
    /// </summary>
    /// <remarks>
    /// The result is <see cref="BulkDataSyncTaskDataItemResult.NOT_MODIFIED"/> by default.
    /// </remarks>
    [XmlElement("result")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public BulkDataSyncTaskDataItemResult? Result { get; init; }

    /// <summary>
    /// Gets or sets the data item error message.
    /// </summary>
    [XmlElement("errorMessage")]
    public string? ErrorMessage { get; init; }

    /// <summary>
    /// Gets or sets the data item error data.
    /// </summary>
    //[XmlElement("errorData")]
    [XmlIgnore]
    public object? ErrorData { get; init; }
}