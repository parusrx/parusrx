// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Services;

public sealed class OrganizationOmsService(HttpClient httpClient) : IOrganizationOmsService
{
    public async ValueTask<SingleResponse<OrganizationOms>> GetAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"org/oms/get", queryParameters);
        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }
        return await response.Content.ReadFromJsonAsync<SingleResponse<OrganizationOms>>(cancellationToken) ?? new();
    }

    public async ValueTask<ListPagedResponse<OrganizationOms>> ListPagedAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"org/oms", queryParameters);
        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }
        return await response.Content.ReadFromJsonAsync<ListPagedResponse<OrganizationOms>>(cancellationToken) ?? new();
    }

    public async ValueTask<DefaultResponse> UpdateAsync(Dictionary<string, string?> queryParameters, OrganizationOms organizationOms, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"org/oms", queryParameters);
        var response = await httpClient.PutAsJsonAsync(requestUri, organizationOms, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }
        return await response.Content.ReadFromJsonAsync<DefaultResponse>(cancellationToken) ?? new();
    }
}
