// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Net.Http.Json;

using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

namespace ParusRx.Egisz.Ips.IdentityProvider;

public class IdentityService(HttpClient httpClient, IDistributedCache cache, IOptionsSnapshot<IdentitySettings> settings) : IIdentityService
{
    public async ValueTask<AccessToken?> GetAccessTokenAsync(CancellationToken cancellationToken = default) =>
        await cache.GetAsync("ips_token", async (cancellationToken) =>
        {
            string identityUrl = $"{settings.Value.Url}/auth/token";
            var response = await httpClient.GetAsync(identityUrl, cancellationToken);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<AccessToken>(cancellationToken);
        }, new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = settings.Value.TokenCacheExpiration
        }, cancellationToken);
}

