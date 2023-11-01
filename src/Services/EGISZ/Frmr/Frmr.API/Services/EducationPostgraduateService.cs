// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Services;

public class EducationPostgraduateService(HttpClient httpClient, IOptionsSnapshot<FrmrSettings> settings)
{
    public async ValueTask<GetEducationPostgraduateResponse> GetAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/postgraduate", queryParameters);
        
        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<GetEducationPostgraduateResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<CreateEducationPostgraduateResponse> CreateAsync(Dictionary<string, string?> queryParameters, EducationPostgraduate educationPostgraduate, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/postgraduate", queryParameters);
        
        var response = await httpClient.PostAsJsonAsync(requestUri, educationPostgraduate, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<CreateEducationPostgraduateResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<UpdateEducationPostgraduateResponse> UpdateAsync(Dictionary<string, string?> queryParameters, EducationPostgraduate educationPostgraduate, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/postgraduate", queryParameters);
        
        var response = await httpClient.PutAsJsonAsync(requestUri, educationPostgraduate, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<UpdateEducationPostgraduateResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<DeleteEducationPostgraduateResponse> DeleteAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/postgraduate", queryParameters);
        
        var response = await httpClient.DeleteAsync(requestUri, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<DeleteEducationPostgraduateResponse>(cancellationToken) ?? new();
    }
}
