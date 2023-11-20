// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.Services;

public interface IOrganizationService
{
    ValueTask<SingleResponse<Organization>> GetAsync(string oid, CancellationToken cancellationToken = default);
    ValueTask<ListPagedResponse<Organization>> ListPagedAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default);
    ValueTask<DefaultResponse> UpdateAsync(Dictionary<string, string?> queryParameters, Organization organization, CancellationToken cancellationToken = default);
    ValueTask<DefaultResponse> DeleteAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default);
}
