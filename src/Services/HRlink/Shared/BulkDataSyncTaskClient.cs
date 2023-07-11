// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.Internal;

internal sealed class BulkDataSyncTaskClient : IBulkDataSyncTaskClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BulkDataSyncTaskClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<CreateBulkDataSyncTaskResponse?> CreateBulkDataSyncTaskAsync<TValue>(string baseUri, string clientId, string apiToken, CreateBulkDataSyncTaskRequest<TValue> request, CancellationToken cancellationToken = default)
    {
        var httpClient = CreateHttpClient(baseUri, apiToken);

        string requestUri = $"api/v1/clients/{clientId}/bulkDataSyncTasks";
        var response = await httpClient.PostAsJsonAsync(requestUri, request, cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<CreateBulkDataSyncTaskResponse>(cancellationToken);
    }

    public async Task<BulkDataSyncTaskResponse?> GetFullStatusBulkDataSyncTaskByIdAsync(string baseUri, string clientId, string apiToken, string id, CancellationToken cancellationToken = default)
    {
        var httpClient = CreateHttpClient(baseUri, apiToken);

        string requestUri = $"api/v1/clients/{clientId}/bulkDataSyncTasks/{id}";
        return await httpClient.GetFromJsonAsync<BulkDataSyncTaskResponse>(requestUri, cancellationToken);
    }

    private HttpClient CreateHttpClient(string baseUri, string apiToken)
    {
        var httpClient = _httpClientFactory.CreateClient();
        httpClient.BaseAddress = new Uri(baseUri);
        httpClient.DefaultRequestHeaders.Add("User-Api-Token", apiToken);

        return httpClient;
    }
}
