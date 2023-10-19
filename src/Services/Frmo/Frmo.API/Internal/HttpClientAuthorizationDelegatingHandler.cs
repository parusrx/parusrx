// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Net.Http.Headers;

namespace ParusRx.Frmo.API;

internal class HttpClientAuthorizationDelegatingHandler(IIdentityService identityService) : DelegatingHandler
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
