// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Services;

public interface IDepartmentService
{
    ValueTask<SingleResponse<Department>> GetAsync(string departOid, Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default);
    ValueTask<ListPagedResponse<Department>> ListPagedAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default);
    ValueTask<SingleResponse<Entity>> CreateAsync(Dictionary<string, string?> queryParameters, Department department, CancellationToken cancellationToken = default);
    ValueTask<DefaultResponse> UpdateAsync(Dictionary<string, string?> queryParameters, Department department, CancellationToken cancellationToken = default);
    ValueTask<DefaultResponse> DeleteAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default);
}
