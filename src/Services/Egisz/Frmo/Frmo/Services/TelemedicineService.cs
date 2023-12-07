// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.


namespace ParusRx.Egisz.Frmo.Services;

public sealed class TelemedicineService(HttpClient httpClient) : ITelemedicineService
{
    public async ValueTask<ListResponse<Telemedicine>> ListAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"org/telemedicine", queryParameters);

        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }

        var result = await response.Content.ReadFromJsonAsync<ListResponse<Telemedicine>>(cancellationToken);
        return result!;
    }

    public async ValueTask<SingleResponse<Telemedicine>> GetAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"org/telemedicine/get", queryParameters);

        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }

        var result = await response.Content.ReadFromJsonAsync<SingleResponse<Telemedicine>>(cancellationToken);
        return result!;
    }

    public async ValueTask<SingleResponse<Entity>> CreateAsync(Dictionary<string, string?> queryParameters, Telemedicine telemedicine, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"org/telemedicine", queryParameters);

        var response = await httpClient.PostAsJsonAsync(requestUri, telemedicine, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }

        var result = await response.Content.ReadFromJsonAsync<SingleResponse<Entity>>(cancellationToken);
        return result!;
    }

    public async ValueTask<DefaultResponse> UpdateAsync(Dictionary<string, string?> queryParameters, Telemedicine telemedicine, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"org/telemedicine", queryParameters);

        var response = await httpClient.PutAsJsonAsync(requestUri, telemedicine, cancellationToken);
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
        var requestUri = QueryHelpers.AddQueryString($"org/telemedicine", queryParameters);

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
