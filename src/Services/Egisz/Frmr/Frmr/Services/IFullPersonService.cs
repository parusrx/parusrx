// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.Services;

public interface IFullPersonService
{
    public ValueTask<SingleResponse<FullPerson>> GetAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken);
}
