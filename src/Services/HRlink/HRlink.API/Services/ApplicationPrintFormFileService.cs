// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Text;

namespace ParusRx.HRlink.API.Services;

public sealed class ApplicationPrintFormFileService(HttpClient httpClient) : IApplicationPrintFormFileService
{
    public async ValueTask<PrintFormFileResponse> GetPrintFormFileAsync(PrintFormFileRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        string uri = $"{request.Authorization.Url}/api/v1/clients/{request.Authorization.ClientId}/applications/{request.ApplicationId}/printFormFile";
        httpClient.DefaultRequestHeaders.Add("User-Api-Token", request.Authorization.ApiToken);

        var response = await httpClient.GetAsync(uri, cancellationToken);

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

        string? fileName = response.Content.Headers.ContentDisposition?.FileName?.Trim('"');
        byte[]? data = await response.Content.ReadAsByteArrayAsync(cancellationToken);

        return new PrintFormFileResponse
        { 
            FileName = fileName,
            Data = Convert.ToBase64String(data ?? [])
        };
    }
}
