// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DaData.Api.Services;

/// <summary>
/// The default implementation of <see cref="SuggestPartyService"/>.
/// </summary>
public class SuggestPartyService : ISuggestPartyService
{
    private readonly HttpClient _httpClient;
    private readonly DaDataSettings _settings;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    /// <summary>
    /// Initializes a new instance of <see cref="SuggestPartyService"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    /// <param name="settings">The DaData settings.</param>
    public SuggestPartyService(HttpClient httpClient, IOptions<DaDataSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings.Value;

        _jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
    }

    /// <inheritdoc/>
    public async Task<byte[]> FindByIdAsync(DaDataSuggestPartyRequest suggestionsRequest)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"{_settings.Suggestions}/findById/party");
        request.Headers.Authorization = new AuthenticationHeaderValue("Token", suggestionsRequest?.Authorization?.AccessToken);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

        request.Content = new StringContent(JsonSerializer.Serialize(suggestionsRequest?.SuggestPartyRequest), Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsByteArrayAsync();
    }
}
