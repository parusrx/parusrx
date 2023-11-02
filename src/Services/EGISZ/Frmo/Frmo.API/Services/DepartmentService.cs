// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.


namespace ParusRx.Frmo.API.Services;

public class DepartmentService(HttpClient httpClient, IOptionsSnapshot<FrmoSettings> settings) : IDepartmentService
{
    public async ValueTask<SingleResponse<Department>> GetAsync(string departOid, Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/org/depart/{departOid}", queryParameters);

        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<SingleResponse<Department>>(cancellationToken) ?? new();
    }

    public async ValueTask<ListPagedResponse<Department>> ListPagedAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/org/depart", queryParameters);

        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<ListPagedResponse<Department>>(cancellationToken) ?? new();
    }

    public async ValueTask<SingleResponse<Entity>> CreateAsync(Dictionary<string, string?> queryParameters, Department department, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/org/depart", queryParameters);

        var response = await httpClient.PostAsJsonAsync(requestUri, department, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<SingleResponse<Entity>>(cancellationToken) ?? new();
    }

    public async ValueTask<DefaultResponse> UpdateAsync(Dictionary<string, string?> queryParameters, Department department, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/org/depart", queryParameters);

        var response = await httpClient.PutAsJsonAsync(requestUri, department, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<DefaultResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<DefaultResponse> DeleteAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/org/depart", queryParameters);

        var response = await httpClient.DeleteAsync(requestUri, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<DefaultResponse>(cancellationToken) ?? new();
    }
}
