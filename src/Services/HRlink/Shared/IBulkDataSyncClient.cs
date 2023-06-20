// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.Internal;

internal interface IBulkDataSyncClient
{
    Task<CreateBulkDataSyncTaskResponse?> CreateBulkDataSyncTaskAsync<TValue>(string baseUri, string clientId, string apiToken, CreateBulkDataSyncTaskRequest<TValue> request, CancellationToken cancellationToken = default);
    Task<BulkDataSyncTaskResponse?> GetFullStatusBulkDataSyncTaskById(string baseUri, string clientId, string apiToken, string id, CancellationToken cancellationToken = default);
}
