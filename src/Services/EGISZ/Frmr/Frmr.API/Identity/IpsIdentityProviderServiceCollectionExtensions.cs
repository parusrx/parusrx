// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Microsoft.Extensions.DependencyInjection;

public static class IpsIdentityProviderServiceCollectionExtensions
{
    public static IServiceCollection AddIpsIdentityProvider(this IServiceCollection services)
    {
        services.AddHttpClient<IIdentityService, IdentityService>();

        return services;
    }
}
