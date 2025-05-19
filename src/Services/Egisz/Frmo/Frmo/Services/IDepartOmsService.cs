// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Services;

public interface IDepartOmsService
{
    ValueTask<ListResponse<DepartOms>> ListAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default);
    ValueTask<SingleResponse<DepartOms>> GetAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default);
    ValueTask<DefaultResponse> UpdateAsync(Dictionary<string, string?> queryParameters, DepartOms departOms, CancellationToken cancellationToken = default);
}
