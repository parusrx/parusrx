// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Services;

public interface ILicenseService
{
    ValueTask<ListResponse<License>> ListAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken);
    ValueTask<SingleResponse<License>> GetAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken);
}
