// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API.Services;

public class DepartmentService(HttpClient httpClient, IOptionsSnapshot<FrmoSettings> settings) : IDepartmentService
{
    public async ValueTask<GetByOidDepartmentResponse> GetByOidAsync(string departOid, string oid, CancellationToken cancellationToken = default)
    {
        string url = $"{settings.Value.Url}/org/depart/{departOid}?oid={oid}";

        var response = await httpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<GetByOidDepartmentResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<ListPagedDepartmentResponse> ListPagedAsync(int departTypeId, string oid, int offset = 0, int limit = 10, CancellationToken cancellationToken = default)
    {
        string url = $"{settings.Value.Url}/org/depart?departTypeId={departTypeId}&oid={oid}&offset={offset}&limit={limit}";

        var response = await httpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<ListPagedDepartmentResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<CreateDepartmentResponse> CreateAsync(string oid, Department department, CancellationToken cancellationToken = default)
    {
        string url = $"{settings.Value.Url}/org/depart?oid={oid}";

        var response = await httpClient.PostAsJsonAsync(url, department, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<CreateDepartmentResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<UpdateDepartmentResponse> UpdateAsync(string oid, string entityId, Department department, CancellationToken cancellationToken = default)
    {
        string url = $"{settings.Value.Url}/org/depart?oid={oid}&entityId={entityId}";

        var response = await httpClient.PutAsJsonAsync(url, department, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<UpdateDepartmentResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<DeleteDepartmentResponse> DeleteAsync(string oid, string entityId, CancellationToken cancellationToken = default)
    {
        string url = $"{settings.Value.Url}/org/depart?oid={oid}&entityId={entityId}";

        var response = await httpClient.DeleteAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<DeleteDepartmentResponse>(cancellationToken) ?? new();
    }
}
