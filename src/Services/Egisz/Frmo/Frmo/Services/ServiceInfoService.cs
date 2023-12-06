// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Services;

public sealed class ServiceInfoService(HttpClient httpClient) : IServiceInfoService
{
    public async ValueTask<ListResponse<ServiceInfo>> ListAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"org/servicesInfo", queryParameters);

        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }

        var result = await response.Content.ReadFromJsonAsync<ListResponse<ServiceInfo>>(cancellationToken);
        return result!;
    }

    public async ValueTask<SingleResponse<Entity>> CreateAsync(Dictionary<string, string?> queryParameters, ServiceInfo serviceInfo, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"org/servicesInfo", queryParameters);

        var response = await httpClient.PostAsJsonAsync(requestUri, serviceInfo, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }

        var result = await response.Content.ReadFromJsonAsync<SingleResponse<Entity>>(cancellationToken);
        return result!;
    }

    public async ValueTask<DefaultResponse> UpdateAsync(Dictionary<string, string?> queryParameters, ServiceInfo serviceInfo, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"org/servicesInfo", queryParameters);

        var response = await httpClient.PutAsJsonAsync(requestUri, serviceInfo, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }

        var result = await response.Content.ReadFromJsonAsync<DefaultResponse>(cancellationToken);
        return result!;
    }

    public async ValueTask<DefaultResponse> DeleteAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"org/servicesInfo", queryParameters);

        var response = await httpClient.DeleteAsync(requestUri, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }

        var result = await response.Content.ReadFromJsonAsync<DefaultResponse>(cancellationToken);
        return result!;
    }
}
