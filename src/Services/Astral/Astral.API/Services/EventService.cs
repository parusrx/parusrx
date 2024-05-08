// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace ParusRx.Astral.API.Services;

public sealed class EventService(HttpClient httpClient) : IEventService
{
    public async ValueTask<PublishEventsResponse?> PublishEventsAsync(CreatePublishEventsRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        string uri = $"{request.Authorization.Url}/events";
        httpClient.DefaultRequestHeaders.Add("X-API-Key", request.Authorization.ApiKey);

        JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        var response = await httpClient.PostAsJsonAsync(uri, request.PublishEventsRequest, options, cancellationToken);

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
