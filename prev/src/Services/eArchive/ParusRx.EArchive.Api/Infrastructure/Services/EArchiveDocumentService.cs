// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EArchive.Api.Services;

/// <summary>
/// The default implementation of <see cref="IEArchiveDocumentService"/>.
/// </summary>
public class EArchiveDocumentService : IEArchiveDocumentService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    /// <summary>
    /// Initializes a new instance of <see cref="EArchiveDocumentService"/>.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    /// <param name="settings">The URL settings.</param>
    public EArchiveDocumentService(HttpClient httpClient, IOptions<UrlsSettings> settings)
    {
        _httpClient = httpClient;
        _baseUrl = settings?.Value?.EArchive;

        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        _jsonSerializerOptions.Converters.Add(new DecimalConverter());
    }

    /// <inheritdoc/>
    public async Task<string> ReadAttachmentAsync(string id, string accessToken)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/document/readAttachment?id={id}");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var response = await _httpClient.SendAsync(request);
        response.IntegrationEnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }

    /// <inheritdoc/>
    public async Task<Document> ReadCardByIdAsync(string id, string accessToken)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/document/readCardById?id={id}");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var response = await _httpClient.SendAsync(request);
        response.IntegrationEnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<Document>(options: _jsonSerializerOptions);
    }

    /// <inheritdoc/>
    public async Task<Document> ReadCardAsync(string systemCode, string externalId, string accessToken)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/document/readCard?systemCode={systemCode}&extId={externalId}");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var response = await _httpClient.SendAsync(request);
        response.IntegrationEnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<Document>(options: _jsonSerializerOptions);
    }

    /// <inheritdoc/>
    public async Task<Document> StoreAsync(StoreDocumentBody document, string accessToken)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/document/store");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        request.Content = JsonContent.Create(document);

        var response = await _httpClient.SendAsync(request);
        response.IntegrationEnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<Document>(options: _jsonSerializerOptions);
    }
}
