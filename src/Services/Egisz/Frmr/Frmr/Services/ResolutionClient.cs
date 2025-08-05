// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.Services;

public sealed class ResolutionClient(HttpClient httpClient) : IResolutionClient
{
    public async ValueTask<ListResponse<Resolution>> ListAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken)
    {
        var requestUri = QueryHelpers.AddQueryString($"resolution", queryParameters);
        
        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new HttpResponseException((int)response.StatusCode, problemDetails);
        }
        
        return await response.Content.ReadFromJsonAsync<ListResponse<Resolution>>(cancellationToken) ?? new();
    }
}
