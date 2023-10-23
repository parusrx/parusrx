// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

public interface IIdentityService
{
    ValueTask<AccessToken?> GetAccessTokenAsync(CancellationToken cancellationToken = default);
}
