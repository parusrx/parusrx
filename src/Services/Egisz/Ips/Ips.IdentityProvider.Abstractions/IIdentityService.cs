// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Ips.IdentityProvider;

public interface IIdentityService
{
    ValueTask<AccessToken?> GetAccessTokenAsync(CancellationToken cancellationToken = default);
}
