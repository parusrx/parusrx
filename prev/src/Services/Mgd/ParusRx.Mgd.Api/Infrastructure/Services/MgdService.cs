// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Infrastructure.Services;

/// <summary>
/// Default implementation of <see cref="IMgdService"/>.
/// </summary>
public class MgdService : IMgdService
{
    private readonly HttpClient _httpClient;
    private readonly UrlsSettings _settings;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="MgdService"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    /// <param name="settings">The URL settings</param>
    public MgdService(HttpClient httpClient, IOptions<UrlsSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings.Value;
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    /// <inheritdoc/>
    public async Task<Message> GetMessageAsync(string token)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_settings.Mgd}/api/esb/getMessage");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var message = await response.Content.ReadFromJsonAsync<Message>(options: _jsonSerializerOptions);
        return message != null && !string.IsNullOrEmpty(message.Data) ? message : null;
    }

    /// <inheritdoc/>
    public async Task<MgdResponse> SendTicketAsync(Ticket ticket, string token)
    {
        var content = new StringContent(JsonSerializer.Serialize(ticket, _jsonSerializerOptions));

        var request = new HttpRequestMessage(HttpMethod.Post, $"{_settings.Mgd}/api/esb/pushInvoice");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        request.Content = content;

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var mgdResponse = await response.Content.ReadFromJsonAsync<MgdResponse>(options: _jsonSerializerOptions);
        return !string.IsNullOrEmpty(mgdResponse.Response) ? mgdResponse : null;
    }
}
