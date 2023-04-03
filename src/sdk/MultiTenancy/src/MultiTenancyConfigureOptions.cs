// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.Extensions.Configuration;

namespace ParusRX.MultiTenancy;

/// <summary>
/// Represents something that configures <see cref="MultiTenancyOptions"/>.
/// </summary>
/// <typeparam name="TTenant">Tenant type.</typeparam>
public class MultiTenancyConfigureOptions<TTenant> : IConfigureOptions<MultiTenancyOptions>
    where TTenant : class, ITenant
{
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Initializes a new instance of the <see cref="MultiTenancyConfigureOptions{TTenant}"/> class.
    /// </summary>
    /// <param name="configuration">Configuration.</param>
    public MultiTenancyConfigureOptions(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <inheritdoc/>
    public void Configure(MultiTenancyOptions options)
    {
        var tenants = _configuration.GetSection("Tenants").Get<List<TTenant>>();
        if (tenants is not null)
        {
            options.Tenants.AddRange((IEnumerable<ITenant>)tenants);
        }
    }
}