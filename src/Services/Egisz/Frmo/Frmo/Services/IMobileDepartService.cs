// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Services;

public interface IMobileDepartService
{
    ValueTask<ListResponse<MobileDepart>> ListAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken);
    ValueTask<SingleResponse<MobileDepart>> GetAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken);
    ValueTask<SingleResponse<Entity>> CreateAsync(Dictionary<string, string?> queryParameters, MobileDepart mobileDepart, CancellationToken cancellationToken);
    ValueTask<DefaultResponse> UpdateAsync(Dictionary<string, string?> queryParameters, MobileDepart mobileDepart, CancellationToken cancellationToken);
    ValueTask<DefaultResponse> DeleteAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken);
}
