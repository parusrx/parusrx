// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mis.API.Organizations;

public sealed class DepartmentService(HttpClient httpClient, IOptionsSnapshot<EgiszSettings> settings)
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
}
