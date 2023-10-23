// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

public class OrganizationService(HttpClient httpClient, IOptionsSnapshot<FrmoSettings> settings) : IOrganizationService
{
    public async ValueTask<GetByOidOrganizationResponse> GetByOidAsync(string oid, CancellationToken cancellationToken = default)
    {
        string url = $"{settings.Value.Url}/org/{oid}";

        var response = await httpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<GetByOidOrganizationResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<ListPagedOrganizationResponse> ListPagedAsync(int orgTypeId, int offset = 0, int limit = 10, CancellationToken cancellationToken = default)
    {
        string url = $"{settings.Value.Url}/org?orgTypeId={orgTypeId}&offset={offset}&limit={limit}";
        
        var response = await httpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<ListPagedOrganizationResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<UpdateOrganizationResponse> UpdateAsync(string oid, Organization organization, CancellationToken cancellationToken = default)
    {
        string url = $"{settings.Value.Url}/org?oid={oid}";

        var response = await httpClient.PutAsJsonAsync(url, organization, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<UpdateOrganizationResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<DeleteOrganizationResponse> DeleteAsync(string oid, int deleteReason, CancellationToken cancellationToken = default)
    {
        string url = $"{settings.Value.Url}/org?oid={oid}&deleteReason={deleteReason}";

        var response = await httpClient.DeleteAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<DeleteOrganizationResponse>(cancellationToken) ?? new();
    }
}
