// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Infrastructure.Services;

/// <summary>
/// Default implementation of <see cref="ICipherService"/>.
/// </summary>
public class CipherService : ICipherService
{
    private readonly HttpClient _httpClient;
    private readonly UrlsSettings _urls;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="CipherService"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    /// <param name="urlsSettings">The URL settings.</param>
    public CipherService(HttpClient httpClient, IOptions<UrlsSettings> urlsSettings)
    {
        _httpClient = httpClient;
        _urls = urlsSettings.Value;

        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    /// <inheritdoc/>
    public async Task<string> SignXmlAsync(SignData data)
    {
        var url = _urls.Cipher + UrlsSettings.CipherOperations.SignXml;
        var response = await PostAsync(data, url);

        return await response.Content.ReadAsStringAsync();
    }

    /// <inheritdoc/>
    public async Task<bool> VerifyXmlAsync(VerifyData data)
    {
        var url = _urls.Cipher + UrlsSettings.CipherOperations.VerifyXml;
        var response = await PostAsync(data, url);

        var result = await response.Content.ReadAsStringAsync();
        return bool.Parse(result);
    }

    private async Task<HttpResponseMessage> PostAsync<T>(T data, string url)
    {
        var content = new StringContent(JsonSerializer.Serialize(data, _jsonSerializerOptions), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, content);

        response.EnsureSuccessStatusCode();

        return response;
    }
}
