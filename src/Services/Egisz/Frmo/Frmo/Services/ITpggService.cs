// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Services;

public interface ITpggService
{
    ValueTask<ListResponse<Tpgg>> ListAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default);
}
