// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Services;

public interface IApplicationGroupService
{
    ValueTask<GetHrRegistryV2ApplicationGroupsResponse?> GetApplicationGroupsAsync(GetHrRegistryV2ApplicationGroupsRequest request, CancellationToken cancellationToken = default);
}
