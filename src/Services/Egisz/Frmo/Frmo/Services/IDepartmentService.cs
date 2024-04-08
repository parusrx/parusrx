// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Services;

public interface IDepartmentService
{
    ValueTask<SingleResponse<Department>> GetAsync(string departOid, Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default);
    ValueTask<ListPagedResponse<Department>> ListPagedAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default);
    ValueTask<SingleResponse<Entity>> CreateAsync(Dictionary<string, string?> queryParameters, Department department, CancellationToken cancellationToken = default);
    ValueTask<DefaultResponse> UpdateAsync(Dictionary<string, string?> queryParameters, Department department, CancellationToken cancellationToken = default);
    ValueTask<DefaultResponse> DeleteAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default);
}
