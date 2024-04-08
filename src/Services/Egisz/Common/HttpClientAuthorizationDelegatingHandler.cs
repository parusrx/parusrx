// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Net.Http.Headers;
using ParusRx.Egisz.Ips.IdentityProvider;

namespace ParusRx.Egisz.Common;

public class HttpClientAuthorizationDelegatingHandler(IIdentityService identityService) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var accessToken = await identityService.GetAccessTokenAsync(cancellationToken);

        if (accessToken is not null)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}

