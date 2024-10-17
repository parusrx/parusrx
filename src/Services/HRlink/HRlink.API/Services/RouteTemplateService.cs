// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Text;

namespace ParusRx.HRlink.API.Services;

/// <summary>
/// Provides methods allowing to work with route templates in HRlink.
/// </summary>
/// <param name="httpClient">The <see cref="HttpClient"/>.</param>
public sealed class RouteTemplateService(HttpClient httpClient) : IRouteTemplateService
{
    /// <inheritdoc />
    public async ValueTask<RouteTemplateResponse?> GetRouteTemplatesAsync(RouteTemplateRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        string uri = $"{request.Authorization.Url}/api/v1/clients/{request.Authorization.ClientId}/routeTemplates";
        httpClient.DefaultRequestHeaders.Add("User-Api-Token", request.Authorization.ApiToken);

        HttpResponseMessage response = await httpClient.GetAsync(uri, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var errorDetails = await response.Content.ReadFromJsonAsync<ErrorDetails>(cancellationToken);
            StringBuilder sb = new();
            sb.AppendLine(errorDetails?.ErrorMessage);
            sb.AppendLine($"Error ID: {errorDetails?.ErrorId}");
            sb.AppendLine($"Error Code: {errorDetails?.ErrorCode}");
            sb.AppendLine($"Operation Code: {errorDetails?.OperationCode}");
            if (errorDetails?.ErrorData is not null)
            {
                sb.AppendLine("Error Data:");
                foreach (var (key, value) in errorDetails.ErrorData)
                {
                    sb.AppendLine($"{key}: {value?.ToString()}");
                }
            }
            throw new HttpRequestException(
                sb.ToString(),
                null,
                response.StatusCode);
        }
        var str = await response.Content.ReadAsStringAsync(cancellationToken);
        var routeTemplateResponse = await response.Content.ReadFromJsonAsync<RouteTemplateResponse>(cancellationToken);
        return routeTemplateResponse;
    }
}
