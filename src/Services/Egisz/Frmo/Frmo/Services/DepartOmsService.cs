// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Services;

public sealed class DepartOmsService(HttpClient httpClient) : IDepartOmsService
{
    public async ValueTask<SingleResponse<DepartOms>> GetAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"/org/depart/oms/get", queryParameters);
        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }
        return await response.Content.ReadFromJsonAsync<SingleResponse<DepartOms>>(cancellationToken) ?? new();
    }

    public async ValueTask<ListResponse<DepartOms>> ListAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"/org/depart/oms", queryParameters);
        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }
        return await response.Content.ReadFromJsonAsync<ListResponse<DepartOms>>(cancellationToken) ?? new();
    }

    public async ValueTask<DefaultResponse> UpdateAsync(Dictionary<string, string?> queryParameters, DepartOms departOms, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"/org/depart/oms", queryParameters);
        var response = await httpClient.PutAsJsonAsync(requestUri, departOms, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }
        return await response.Content.ReadFromJsonAsync<DefaultResponse>(cancellationToken) ?? new();
    }
}
