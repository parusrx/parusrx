// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.MultiTenancy;

/// <summary>
/// Tenant service.
/// </summary>
public class TenantService : ICurrentTenant, ITenantService
{
    /// <inheritdoc/>
    public ITenant? Tenant { get; private set; }

    /// <inheritdoc/>
    public void SetTenant(ITenant tenant)
    {
        Tenant = tenant;
    }
}