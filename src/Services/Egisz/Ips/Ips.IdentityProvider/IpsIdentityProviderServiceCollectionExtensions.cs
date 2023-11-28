// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.Extensions.Configuration;
using ParusRx.Egisz.Ips.IdentityProvider;

namespace Microsoft.Extensions.DependencyInjection;

public static class IpsIdentityProviderServiceCollectionExtensions
{
    public static IServiceCollection AddIpsIdentityProvider(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<IdentitySettings>(configuration.GetSection(IdentitySettings.Identity));
        services.AddHttpClient<IIdentityService, IdentityService>();

        return services;
    }
}
