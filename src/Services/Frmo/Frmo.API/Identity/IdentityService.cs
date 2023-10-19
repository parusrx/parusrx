// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.Extensions.Caching.Distributed;

namespace ParusRx.Frmo.API;

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
