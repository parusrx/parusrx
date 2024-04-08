// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Services;

public interface IOrganizationService
{
    ValueTask<SingleResponse<Organization>> GetAsync(string oid, CancellationToken cancellationToken = default);
    ValueTask<ListPagedResponse<Organization>> ListPagedAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default);
    ValueTask<DefaultResponse> UpdateAsync(Dictionary<string, string?> queryParameters, Organization organization, CancellationToken cancellationToken = default);
    ValueTask<DefaultResponse> DeleteAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default);
}
