// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mis.API.Persons;

public sealed class FullPersonService(HttpClient httpClient, IOptionsSnapshot<EgiszSettings> settings)
{
    public async ValueTask<SingleResponse<FullPerson>> GetAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"{settings.Value.Url}/person/full", queryParameters);
        
        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }

        return await response.Content.ReadFromJsonAsync<SingleResponse<FullPerson>>(cancellationToken) ?? new();
    }
}

