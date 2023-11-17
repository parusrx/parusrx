// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Services;

public sealed class EducationProfService(HttpClient httpClient, IOptionsSnapshot<FrmrSettings> settings) : IEducationProfService
{
    public async ValueTask<SingleResponse<EducationProf>> GetAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/prof", queryParameters);
        
        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }
        
        return await response.Content.ReadFromJsonAsync<SingleResponse<EducationProf>>(cancellationToken) ?? new();
    }

    public async ValueTask<SingleResponse<Entity>> CreateAsync(Dictionary<string, string?> queryParameters, EducationProf educationProf, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/prof", queryParameters);
        
        var response = await httpClient.PostAsJsonAsync(requestUri, educationProf, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }
        
        return await response.Content.ReadFromJsonAsync<SingleResponse<Entity>>(cancellationToken) ?? new();
    }

    public async ValueTask<DefaultResponse> UpdateAsync(Dictionary<string, string?> queryParameters, EducationProf educationProf, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/prof", queryParameters);
        
        var response = await httpClient.PutAsJsonAsync(requestUri, educationProf, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }
        
        return await response.Content.ReadFromJsonAsync<DefaultResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<DefaultResponse> DeleteAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/prof", queryParameters);
        
        var response = await httpClient.DeleteAsync(requestUri, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }
        
        return await response.Content.ReadFromJsonAsync<DefaultResponse>(cancellationToken) ?? new();
    }
}
