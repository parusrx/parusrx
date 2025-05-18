// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Text;

namespace ParusRx.HRlink.API.Services;

/// <summary>
/// Provides functionality to interact with application types through a remote API.
/// </summary>
/// <remarks>This service is used to retrieve application type information by making HTTP requests to a specified
/// API endpoint. It requires a valid authorization token and URL to function correctly.</remarks>
/// <param name="httpClient">The <see cref="HttpClient"/> used to make HTTP requests.</param>
public sealed class ApplicationTypeService(HttpClient httpClient) : IApplicationTypeService
{
    /// </inheritdoc />
    public async ValueTask<ApplicationTypeResponse?> GetApplicationTypesAsync(ApplicationTypeRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        string uri = $"{request.Authorization.Url}/api/v1/applicationTypes";
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
        var applicationTypeResponse = await response.Content.ReadFromJsonAsync<ApplicationTypeResponse>(cancellationToken);
        return applicationTypeResponse;
    }
}
