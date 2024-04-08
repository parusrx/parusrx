// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.BulkDataSyncTasks;

/// <summary>
/// Represents a request to create a bulk data sync task.
/// </summary>
/// <typeparam name="TValue">The type of the data item value.</typeparam>
/// <param name="Type">The type of the bulk data sync task.</param>
/// <param name="Data">The data items.</param>
public sealed record CreateBulkDataSyncTaskRequest<TValue>([property: JsonConverter(typeof(JsonStringEnumConverter))] BulkDataSyncTaskType Type, IEnumerable<TValue> Data);