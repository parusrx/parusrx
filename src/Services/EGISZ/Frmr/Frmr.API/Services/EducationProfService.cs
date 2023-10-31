// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Services;

public sealed class EducationProfService(HttpClient httpClient, IOptionsSnapshot<FrmrSettings> settings)
{
    public async ValueTask<GetEducationProfResponse> GetAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/prof", queryParameters);
        
        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<GetEducationProfResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<CreateEducationProfResponse> CreateAsync(Dictionary<string, string?> queryParameters, EducationProf educationProf, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/prof", queryParameters);
        
        var response = await httpClient.PostAsJsonAsync(requestUri, educationProf, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<CreateEducationProfResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<UpdateEducationProfResponse> UpdateAsync(Dictionary<string, string?> queryParameters, EducationProf educationProf, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/prof", queryParameters);
        
        var response = await httpClient.PutAsJsonAsync(requestUri, educationProf, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<UpdateEducationProfResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<DeleteEducationProfResponse> DeleteAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/prof", queryParameters);
        
        var response = await httpClient.DeleteAsync(requestUri, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<DeleteEducationProfResponse>(cancellationToken) ?? new();
    }
}
