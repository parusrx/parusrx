// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Services;

public interface ITpggService
{
    ValueTask<ListResponse<Tpgg>> ListAsync(Dictionary<string, string?> queryParameters, CancellationToken cancellationToken = default);
}
