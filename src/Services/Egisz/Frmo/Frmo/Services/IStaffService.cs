// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.Services;

public interface IStaffService
{
    ValueTask<ListResponse<Staff>> ListAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default);
    ValueTask<SingleResponse<Staff>> GetAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default);
    ValueTask<SingleResponse<Entity>> CreateAsync(Dictionary<string, string?> queryParameters, Staff staff, CancellationToken cancellationToken = default);
    ValueTask<DefaultResponse> UpdateAsync(Dictionary<string, string?> queryParameters, Staff staff, CancellationToken cancellationToken = default);
    ValueTask<DefaultResponse> DeleteAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default);
}
