// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.MultiTenancy;

/// <summary>
/// This interface must be implemented by any service that wants to set tenant for current thread.
/// </summary>
public interface ITenantService
{
    /// <summary>
    /// Set tenant.
    /// </summary>
    /// <param name="tenant">Tenant.</param>
    public void SetTenant(ITenant tenant);
}