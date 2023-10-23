// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

public interface IOrganizationService
{
    ValueTask<GetByOidOrganizationResponse> GetByOidAsync(string oid, CancellationToken cancellationToken = default);
    ValueTask<ListPagedOrganizationResponse> ListPagedAsync(int orgTypeId, int offset = 0, int limit = 10, CancellationToken cancellationToken = default);
    ValueTask<UpdateOrganizationResponse> UpdateAsync(string oid, Organization organization, CancellationToken cancellationToken = default);
    ValueTask<DeleteOrganizationResponse> DeleteAsync(string oid, int deleteReason, CancellationToken cancellationToken = default);
}
