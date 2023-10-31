// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Services;

public class EducationCommonService(HttpClient httpClient, IOptionsSnapshot<FrmrSettings> settings)
{
    public async ValueTask<GetEducationCommonResponse> GetAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/common", queryParameters);
        
        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<GetEducationCommonResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<CreateEducationCommonResponse> CreateAsync(Dictionary<string, string?> queryParameters, EducationCommon educationCommon, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/common", queryParameters);
        
        var response = await httpClient.PostAsJsonAsync(requestUri, educationCommon, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<CreateEducationCommonResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<UpdateEducationCommonResponse> UpdateAsync(Dictionary<string, string?> queryParameters, EducationCommon educationCommon, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/common", queryParameters);
        
        var response = await httpClient.PutAsJsonAsync(requestUri, educationCommon, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<UpdateEducationCommonResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<DeleteEducationCommonResponse> DeleteAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/common", queryParameters);
        
        var response = await httpClient.DeleteAsync(requestUri, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<DeleteEducationCommonResponse>(cancellationToken) ?? new();
    }
}
