// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using ParusRx.Frmo.API.Services;

namespace ParusRx.Frmo.API;

public class StaffService(HttpClient httpClient, IOptionsSnapshot<FrmoSettings> settings) : IStaffService
{
    public async ValueTask<StaffResponse> GetAsync(string oid, CancellationToken cancellationToken = default)
    {
        string url = $"{settings.Value.Url}/org/staff?oid={oid}";

        var response = await httpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<StaffResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<StaffByEntityResponse> GetByEntityAsync(string oid, string entity, CancellationToken cancellationToken = default)
    {
        string url = $"{settings.Value.Url}/org/staff/get?oid={oid}&entity={entity}";

        var response = await httpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<StaffByEntityResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<CreateStaffResponse> CreateAsync(string oid, Staff staff, CancellationToken cancellationToken = default)
    {
        string url = $"{settings.Value.Url}/org/staff?oid={oid}";

        var response = await httpClient.PostAsJsonAsync(url, staff, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<CreateStaffResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<UpdateStaffResponse> UpdateAsync(string oid, string entityId, Staff staff, CancellationToken cancellationToken = default)
    {
        string url = $"{settings.Value.Url}/org/staff?oid={oid}&entityId={entityId}";

        var response = await httpClient.PutAsJsonAsync(url, staff, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<UpdateStaffResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<DeleteStaffResponse> DeleteAsync(string oid, string entityId, CancellationToken cancellationToken = default)
    {
        string url = $"{settings.Value.Url}/org/staff?oid={oid}&entityId={entityId}";

        var response = await httpClient.DeleteAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<DeleteStaffResponse>(cancellationToken) ?? new();
    }
}
