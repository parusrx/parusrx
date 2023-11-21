// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.Services;

public class EquipmentService(HttpClient httpClient) : IEquipmentService
{
    public async ValueTask<ListResponse<Equipment>> ListAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"org/equipment", queryParameters);

        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }

        return await response.Content.ReadFromJsonAsync<ListResponse<Equipment>>(cancellationToken) ?? new();
    }

    public async ValueTask<SingleResponse<Equipment>> GetAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"org/equipment/get", queryParameters);

        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }

        return await response.Content.ReadFromJsonAsync<SingleResponse<Equipment>>(cancellationToken) ?? new();
    }

    public async ValueTask<SingleResponse<Entity>> CreateAsync(Dictionary<string, string?> queryParameters, Equipment equipment, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"org/equipment", queryParameters);

        var response = await httpClient.PostAsJsonAsync(requestUri, equipment, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }

        return await response.Content.ReadFromJsonAsync<SingleResponse<Entity>>(cancellationToken) ?? new();
    }

    public async ValueTask<DefaultResponse> UpdateAsync(Dictionary<string, string?> queryParameters, Equipment equipment, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"org/equipment", queryParameters);

        var response = await httpClient.PutAsJsonAsync(requestUri, equipment, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }

        return await response.Content.ReadFromJsonAsync<DefaultResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<DefaultResponse> DeleteAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"org/equipment", queryParameters);

        var response = await httpClient.DeleteAsync(requestUri, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }

        return await response.Content.ReadFromJsonAsync<DefaultResponse>(cancellationToken) ?? new();
    }
}
