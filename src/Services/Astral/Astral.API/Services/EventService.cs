// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Text;

namespace ParusRx.Astral.API.Services;

public sealed class EventService(HttpClient httpClient) : IEventService
{
    public async ValueTask<PublishEventsResponse?> PublishEventsAsync(CreatePublishEventsRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        string uri = $"{request.Authorization.Uri}\events";
        httpClient.DefaultRequestHeaders.Add("X-API-Key", request.Authorization.ApiKey);

        var response = await httpClient.PostAsJsonAsync(uri, request.PublishEventsRequest, cancellationToken);

        if (!response.IsSuccessStatusCode) 
        {
            var badResponse = await response.Content.ReadFromJsonAsync<BadResponse>(cancellationToken);

            StringBuilder sb = new();
            sb.AppendFormat("{0} {1}.", badResponse?.Status, badResponse?.Title);
            sb.AppendLine();
            sb.AppendLine(badResponse?.Type);
            sb.AppendLine(badResponse?.Detail);

            throw new HttpRequestException(
                sb.ToString(),
                null,
                response.StatusCode);
        }

        return await response.Content.ReadFromJsonAsync<PublishEventsResponse>(cancellationToken);
    }
}
