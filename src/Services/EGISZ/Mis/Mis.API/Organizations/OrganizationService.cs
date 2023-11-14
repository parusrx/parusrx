// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mis.API.Organizations;

public sealed class OrganizationService(HttpClient httpClient, IOptionsSnapshot<EgiszSettings> settings)
{
    public async ValueTask<SingleResponse<Organization>> GetAsync(string oid, CancellationToken cancellationToken = default)
    {
        var requestUri = $"{settings.Value.Url}/org/{oid}";

        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }

        return await response.Content.ReadFromJsonAsync<SingleResponse<Organization>>(cancellationToken) ?? new();
    }
}
