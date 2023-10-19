// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.API.BulkDataSyncTasks;

/// <summary>
/// Represents a request to create a bulk data sync task.
/// </summary>
/// <typeparam name="TValue">The type of the data item value.</typeparam>
/// <param name="Type">The type of the bulk data sync task.</param>
/// <param name="Data">The data items.</param>
public sealed record CreateBulkDataSyncTaskRequest<TValue>([property: JsonConverter(typeof(JsonStringEnumConverter))] BulkDataSyncTaskType Type, IEnumerable<TValue> Data);