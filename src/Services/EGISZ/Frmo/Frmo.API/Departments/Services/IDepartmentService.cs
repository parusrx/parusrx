// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

public interface IDepartmentService
{
    ValueTask<GetByOidDepartmentResponse> GetByOidAsync(string departOid, string oid, CancellationToken cancellationToken = default);
    ValueTask<ListPagedDepartmentResponse> ListPagedAsync(int departTypeId, string oid, int offset = 0, int limit = 10, CancellationToken cancellationToken = default);
    ValueTask<CreateDepartmentResponse> CreateAsync(string oid, Department department, CancellationToken cancellationToken = default);
    ValueTask<UpdateDepartmentResponse> UpdateAsync(string oid, string entityId, Department department, CancellationToken cancellationToken = default);
    ValueTask<DeleteDepartmentResponse> DeleteAsync(string oid, string entityId, CancellationToken cancellationToken = default);
}
