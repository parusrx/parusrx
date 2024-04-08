// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Net.Http.Headers;
using System.Text;

namespace ParusRx.DaData.API.Services;

/// <summary>
/// The default implementation of the <see cref="ISuggestPartyService"/> interface.
/// </summary>
public sealed class SuggestPartyService : ISuggestPartyService
{
    private readonly HttpClient _httpClient;
    private readonly DaDataSettings _settings;

    /// <summary>
    /// Initializes a new instance of the <see cref="SuggestPartyService"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    /// <param name="settings">The settings.</param>
    public SuggestPartyService(HttpClient httpClient, IOptions<DaDataSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings.Value;
    }

    /// <inheritdoc />
    public async Task<byte[]> FindByIdAsync(DaDataSuggestPartyRequest suggestionsRequest, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"{_settings.Suggestions}/findById/party");
        request.Headers.Authorization = new AuthenticationHeaderValue("Token", suggestionsRequest.Authorization.AccessToken);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

        request.Content = new StringContent(JsonSerializer.Serialize(suggestionsRequest.SuggestPartyRequest), Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsByteArrayAsync(cancellationToken);
    }
}
