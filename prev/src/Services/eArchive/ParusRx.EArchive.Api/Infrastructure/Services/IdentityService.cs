// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EArchive.Api.Services;

/// <summary>
/// Default identity service.
/// </summary>
public class IdentityService : IIdentityService
{
    private readonly HttpClient _httpClient;
    private readonly UrlsSettings _settings;

    /// <summary>
    /// Initializes a new instance of <see cref="IdentityService"/>.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    /// <param name="settings">The URL settings.</param>
    public IdentityService(HttpClient httpClient, IOptions<UrlsSettings> settings)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _settings = settings.Value;
    }

    /// <inheritdoc/>
    public async Task<UserToken> GetTokenAsync(string userName, string password)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new ArgumentNullException(nameof(userName));
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentNullException(nameof(password));
        }

        var request = new HttpRequestMessage(HttpMethod.Post, $"{_settings.EArchive}/api/auth/login")
        {
            Content = JsonContent.Create(new
            {
                username = userName,
                password
            })
        };

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var token = await response.Content.ReadFromJsonAsync<UserToken>(options: new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return token;
    }
}
