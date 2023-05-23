// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.MultiTenancy;

/// <summary>
/// Multi-tenancy options.
/// </summary>
public class MultiTenancyOptions
{
    /// <summary>
    /// Tenants.
    /// </summary>
    public List<ITenant> Tenants { get; set; } = new();
}