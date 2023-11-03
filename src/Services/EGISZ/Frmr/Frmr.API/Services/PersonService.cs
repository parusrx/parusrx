// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Services;

public class PersonService(HttpClient httpClient, IOptionsSnapshot<FrmrSettings> settings) : IPersonService
{
    public async ValueTask<ListPagedResponse<Person>> ListAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/list", queryParameters);
        
        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<ListPagedResponse<Person>>(cancellationToken) ?? new();
    }

    public async ValueTask<SingleResponse<Person>> GetAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person", queryParameters);
        
        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<SingleResponse<Person>>(cancellationToken) ?? new();
    }

    public async ValueTask<SingleResponse<Entity>> CreateAsync(Dictionary<string, string?> queryParameters, Person person, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person", queryParameters);
        
        var response = await httpClient.PostAsJsonAsync(requestUri, person, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<SingleResponse<Entity>>(cancellationToken) ?? new();
    }

    public async ValueTask<DefaultResponse> UpdateAsync(Dictionary<string, string?> queryParameters, Person person, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person", queryParameters);
        
        var response = await httpClient.PutAsJsonAsync(requestUri, person, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<DefaultResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<DefaultResponse> DeleteAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person", queryParameters);
        
        var response = await httpClient.DeleteAsync(requestUri, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<DefaultResponse>(cancellationToken) ?? new();
    }
}
