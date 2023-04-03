// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRX.MultiTenancy;

/// <summary>
/// This interface must be implemented by any service that wants to get tenant for current thread.
/// </summary>
public interface ICurrentTenant
{
    /// <summary>
    /// Tenant.
    /// </summary>
    public ITenant? Tenant { get; }
}