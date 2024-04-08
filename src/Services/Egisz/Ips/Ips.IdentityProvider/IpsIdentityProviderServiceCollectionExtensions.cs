// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

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
