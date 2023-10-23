// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

public interface IStaffService
{
    ValueTask<StaffResponse> GetAsync(string oid, CancellationToken cancellationToken = default);
    ValueTask<StaffByEntityResponse> GetByEntityAsync(string oid, string entity, CancellationToken cancellationToken = default);
    ValueTask<CreateStaffResponse> CreateAsync(string oid, Staff staff, CancellationToken cancellationToken = default);
    ValueTask<UpdateStaffResponse> UpdateAsync(string oid, string entityId, Staff staff, CancellationToken cancellationToken = default);
    ValueTask<DeleteStaffResponse> DeleteAsync(string oid, string entityId, CancellationToken cancellationToken = default);
}
