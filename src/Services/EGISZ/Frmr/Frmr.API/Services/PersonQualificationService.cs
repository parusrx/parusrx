﻿// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Services;

public class PersonQualificationService(HttpClient httpClient, IOptionsSnapshot<FrmrSettings> settings)
{
    public async ValueTask<ListResponse<PersonQualification>> GetAllAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/qualification", queryParameters);

        var response = await httpClient.GetAsync(requestUri, cancellationToken);

        return await response.Content.ReadFromJsonAsync<ListResponse<PersonQualification>>(cancellationToken) ?? new();
    }

    public async ValueTask<SingleResponse<Entity>> CreateAsync(Dictionary<string, string?> queryParameters, PersonQualification personQualification, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/qualification", queryParameters);

        var response = await httpClient.PostAsJsonAsync(requestUri, personQualification, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<SingleResponse<Entity>>(cancellationToken) ?? new();
    }

    public async ValueTask<DefaultResponse> UpdateAsync(Dictionary<string, string?> queryParameters, PersonQualification personQualification, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/qualification", queryParameters);

        var response = await httpClient.PutAsJsonAsync(requestUri, personQualification, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<DefaultResponse>(cancellationToken) ?? new();
    }

    public async ValueTask<DefaultResponse> DeleteAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/qualification", queryParameters);

        var response = await httpClient.DeleteAsync(requestUri, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<DefaultResponse>(cancellationToken) ?? new();
    }
}