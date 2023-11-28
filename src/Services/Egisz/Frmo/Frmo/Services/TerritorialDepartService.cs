// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Services;

public class TerritorialDepartService(HttpClient httpClient) : ITerritorialDepartService
{
    public async ValueTask<ListResponse<TerritorialDepart>> ListAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"org/territorialDepart", queryParameters);

        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }

        return await response.Content.ReadFromJsonAsync<ListResponse<TerritorialDepart>>(cancellationToken) ?? new();
    }

    public async ValueTask<SingleResponse<TerritorialDepart>> GetAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"org/territorialDepart/get", queryParameters);

        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }

        return await response.Content.ReadFromJsonAsync<SingleResponse<TerritorialDepart>>(cancellationToken) ?? new();
    }

    public async ValueTask<SingleResponse<Entity>> CreateAsync(Dictionary<string, string?> queryParameters, TerritorialDepart territorialDepart, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"org/territorialDepart", queryParameters);

        var response = await httpClient.PostAsJsonAsync(requestUri, territorialDepart, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }

        return await response.Content.ReadFromJsonAsync<SingleResponse<Entity>>(cancellationToken) ?? new();
    }

    public async ValueTask<DefaultResponse> UpdateAsync(Dictionary<string, string?> queryParameters, TerritorialDepart territorialDepart, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"org/territorialDepart", queryParameters);

        var response = await httpClient.PutAsJsonAsync(requestUri, territorialDepart, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }

        return await response.Content.ReadFromJsonAsync<DefaultResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<DefaultResponse> DeleteAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"org/territorialDepart", queryParameters);

        var response = await httpClient.DeleteAsync(requestUri, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }

        return await response.Content.ReadFromJsonAsync<DefaultResponse>(cancellationToken) ?? new();
    }
}
