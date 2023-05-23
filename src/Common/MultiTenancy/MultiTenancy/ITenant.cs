// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.MultiTenancy;

/// <summary>
/// Tenant.
/// </summary>
public interface ITenant
{
    /// <summary>
    /// Tenant identifier.
    /// </summary>
    public string Name { get; set; }
}