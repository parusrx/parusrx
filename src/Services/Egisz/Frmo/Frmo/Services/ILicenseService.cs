// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Services;

public interface ILicenseService
{
    ValueTask<ListResponse<License>> ListAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken);
    ValueTask<SingleResponse<License>> GetAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken);
}
