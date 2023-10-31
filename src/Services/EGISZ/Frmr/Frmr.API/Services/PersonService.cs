// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Services;

public class PersonService(HttpClient httpClient, IOptionsSnapshot<FrmrSettings> settings)
{
    public async ValueTask<GetPersonResponse> GetAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person", queryParameters);
        
        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<GetPersonResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<ListPagedPersonResponse> ListAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/list", queryParameters);
        
        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<ListPagedPersonResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<CreatePersonResponse> CreateAsync(Dictionary<string, string?> queryParameters, Person person, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person", queryParameters);
        
        var response = await httpClient.PostAsJsonAsync(requestUri, person, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<CreatePersonResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<UpdatePersonResponse> UpdateAsync(Dictionary<string, string?> queryParameters, Person person, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person", queryParameters);
        
        var response = await httpClient.PutAsJsonAsync(requestUri, person, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<UpdatePersonResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<DeletePersonResponse> DeleteAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person", queryParameters);
        
        var response = await httpClient.DeleteAsync(requestUri, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<DeletePersonResponse>(cancellationToken) ?? new();
    }
}
