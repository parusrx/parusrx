// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Net.Http.Json;

namespace ParusRx.HRlink.Internal;

internal sealed class BulkDataSyncClient : IBulkDataSyncClient
{
    private readonly HttpClient _httpClient;

    public BulkDataSyncClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CreateBulkDataSyncTaskResponse?> CreateBulkDataSyncTaskAsync<TValue>(string baseUri, string clientId, string apiToken, CreateBulkDataSyncTaskRequest<TValue> request, CancellationToken cancellationToken = default)
    {
        string requestUri = $"{baseUri}/api/v1/clients/{clientId}/bulkDataSyncTasks";
        var response = await _httpClient.PostAsJsonAsync(requestUri, request, cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<CreateBulkDataSyncTaskResponse>(cancellationToken);
    }

    public async Task<BulkDataSyncTaskResponse?> GetFullStatusBulkDataSyncTaskById(string baseUri, string clientId, string apiToken, string id, CancellationToken cancellationToken = default)
    {
        string requestUri = $"{baseUri}/api/v1/clients/{clientId}/bulkDataSyncTasks/{id}";
        return await _httpClient.GetFromJsonAsync<BulkDataSyncTaskResponse>(requestUri, cancellationToken);
    }
}
