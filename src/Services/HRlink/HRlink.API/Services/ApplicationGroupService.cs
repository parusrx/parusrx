// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Text;
using System.Text.Json;

namespace ParusRx.HRlink.API.Services;

public sealed class ApplicationGroupService(HttpClient httpClient) : IApplicationGroupService
{
    public async ValueTask<GetHrRegistryV2ApplicationGroupsResponse?> GetApplicationGroupsAsync(GetHrRegistryV2ApplicationGroupsRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
    
        string uri = $"{request.Authorization.Url}/api/v2/clients/{request.Authorization.ClientId}/applicationGroups/getHrRegistry";
        httpClient.DefaultRequestHeaders.Add("User-Api-Token", request.Authorization.ApiToken);
        byte[]? responseData = XmlSerializerUtility.Serialize(request);
        var str = responseData is not null ? System.Text.Encoding.UTF8.GetString(responseData) : string.Empty;
        var response = await httpClient.PostAsJsonAsync(uri, request.Filter, cancellationToken);
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

        var applicationGroupsResponse = await response.Content.ReadFromJsonAsync<GetHrRegistryV2ApplicationGroupsResponse>(cancellationToken);
        return applicationGroupsResponse;
    }
}
