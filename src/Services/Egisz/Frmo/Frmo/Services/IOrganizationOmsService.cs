// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Services;

public interface IOrganizationOmsService
{
    ValueTask<ListPagedResponse<OrganizationOms>> ListPagedAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default);
    ValueTask<SingleResponse<OrganizationOms>> GetAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default);
    ValueTask<DefaultResponse> UpdateAsync(Dictionary<string, string?> queryParameters, OrganizationOms organizationOms, CancellationToken cancellationToken = default);
}
