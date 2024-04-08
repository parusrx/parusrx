// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Services;

public interface IServiceInfoService
{
    ValueTask<ListResponse<ServiceInfo>> ListAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken);
    ValueTask<SingleResponse<Entity>> CreateAsync(Dictionary<string, string?> queryParameters, ServiceInfo serviceInfo, CancellationToken cancellationToken);
    ValueTask<DefaultResponse> UpdateAsync(Dictionary<string, string?> queryParameters, ServiceInfo serviceInfo, CancellationToken cancellationToken);
    ValueTask<DefaultResponse> DeleteAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken);
}
