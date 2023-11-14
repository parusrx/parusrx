// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using ParusRx.Frmo.API.Services;

namespace ParusRx.Frmo.API;

public class OrganizationService(HttpClient httpClient, IOptionsSnapshot<FrmoSettings> settings) : IOrganizationService
{
    public async ValueTask<SingleResponse<Organization>> GetAsync(string oid, CancellationToken cancellationToken = default)
    {
        var requestUri = $"{settings.Value.Url}/org/{oid}";

        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }

        return await response.Content.ReadFromJsonAsync<SingleResponse<Organization>>(cancellationToken) ?? new();
    }

    public async ValueTask<ListPagedResponse<Organization>> ListPagedAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/org", queryParameters);
        
        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }

        return await response.Content.ReadFromJsonAsync<ListPagedResponse<Organization>>(cancellationToken) ?? new();
    }

    public async ValueTask<DefaultResponse> UpdateAsync(Dictionary<string, string?> queryParameters, Organization organization, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/org", queryParameters);

        var response = await httpClient.PutAsJsonAsync(requestUri, organization, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }

        return await response.Content.ReadFromJsonAsync<DefaultResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<DefaultResponse> DeleteAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/org", queryParameters);

        var response = await httpClient.DeleteAsync(requestUri, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }

        return await response.Content.ReadFromJsonAsync<DefaultResponse>(cancellationToken) ?? new();
    }
}
