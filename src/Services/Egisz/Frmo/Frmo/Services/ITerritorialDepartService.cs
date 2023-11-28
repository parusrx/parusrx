// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Services;

public interface ITerritorialDepartService
{
    ValueTask<ListResponse<TerritorialDepart>> ListAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default);
    ValueTask<SingleResponse<TerritorialDepart>> GetAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default);
    ValueTask<SingleResponse<Entity>> CreateAsync(Dictionary<string, string?> queryParameters, TerritorialDepart territorialDepart, CancellationToken cancellationToken = default);
    ValueTask<DefaultResponse> UpdateAsync(Dictionary<string, string?> queryParameters, TerritorialDepart territorialDepart, CancellationToken cancellationToken = default);
    ValueTask<DefaultResponse> DeleteAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default);
}
