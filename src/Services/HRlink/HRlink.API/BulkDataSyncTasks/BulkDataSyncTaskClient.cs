// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.BulkDataSyncTasks;

/// <summary>
/// An implementation of <see cref="IBulkDataSyncTaskClient"/> that uses <see cref="HttpClient"/> to communicate with the HRlink Bulk Data Sync Task API.
/// </summary>
public sealed class BulkDataSyncTaskClient : IBulkDataSyncTaskClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="BulkDataSyncTaskClient"/> class.
    /// </summary>
    /// <param name="httpClientFactory">The HTTP client factory.</param>
    public BulkDataSyncTaskClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    /// <inheritdoc/>
    public async Task<CreateBulkDataSyncTaskResponse?> CreateBulkDataSyncTaskAsync<TValue>(string baseUri, string clientId, string apiToken, CreateBulkDataSyncTaskRequest<TValue> request, CancellationToken cancellationToken = default)
    {
        var httpClient = CreateHttpClient(baseUri, apiToken);

        string requestUri = $"api/v1/clients/{clientId}/bulkDataSyncTasks";
        HttpResponseMessage response = await httpClient.PostAsJsonAsync(requestUri, request, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<CreateBulkDataSyncTaskResponse>(cancellationToken);
        }
        else

        {
            string message = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new HttpRequestException(message);
        }
    }

    /// <inheritdoc/>
    public async Task<BulkDataSyncTaskResponse?> GetFullStatusBulkDataSyncTaskByIdAsync(string baseUri, string clientId, string apiToken, string id, CancellationToken cancellationToken = default)
    {
        var httpClient = CreateHttpClient(baseUri, apiToken);

        string requestUri = $"api/v1/clients/{clientId}/bulkDataSyncTasks/{id}";
        HttpResponseMessage response = await httpClient.GetAsync(requestUri, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<BulkDataSyncTaskResponse>(cancellationToken);
        }
        else
        {
            string message = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new HttpRequestException(message);
        }
    }

    private HttpClient CreateHttpClient(string baseUri, string apiToken)
    {
        var httpClient = _httpClientFactory.CreateClient();
        httpClient.BaseAddress = new Uri(baseUri);
        httpClient.DefaultRequestHeaders.Add("User-Api-Token", apiToken);

        return httpClient;
    }
}