﻿// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Services;

public class PersonAccreditationService(HttpClient httpClient, IOptionsSnapshot<FrmrSettings> settings)
{
    public async ValueTask<SingleResponse<PersonAccreditation>> GetAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/accreditation", queryParameters);

        var response = await httpClient.GetAsync(requestUri, cancellationToken);

        return await response.Content.ReadFromJsonAsync<SingleResponse<PersonAccreditation>>(cancellationToken) ?? new();
    }

    public async ValueTask<SingleResponse<Entity>> CreateAsync(Dictionary<string, string?> queryParameters, PersonAccreditation personAccreditation, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/accreditation", queryParameters);

        var response = await httpClient.PostAsJsonAsync(requestUri, personAccreditation, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<SingleResponse<Entity>>(cancellationToken) ?? new();
    }

    public async ValueTask<DefaultResponse> UpdateAsync(Dictionary<string, string?> queryParameters, PersonAccreditation personAccreditation, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/accreditation", queryParameters);

        var response = await httpClient.PutAsJsonAsync(requestUri, personAccreditation, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<DefaultResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<DefaultResponse> DeleteAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/accreditation", queryParameters);

        var response = await httpClient.DeleteAsync(requestUri, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<DefaultResponse>(cancellationToken) ?? new();
    }
}