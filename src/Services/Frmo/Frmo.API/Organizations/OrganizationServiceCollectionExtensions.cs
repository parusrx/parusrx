// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Microsoft.Extensions.DependencyInjection;

public static class OrganizationServiceCollectionExtensions
{
    public static IServiceCollection AddOrganization(this IServiceCollection services) 
    {
        services.AddHttpClient<IOrganizationService, OrganizationService>()
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler 
            { 
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
            })
            .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddTransient<ListPagedOrganizationIntegrationEventHandler>();
        services.AddTransient<GetByOidOrganizationIntegrationEventHandler>();
        services.AddTransient<UpdateOrganizationIntegrationEventHandler>();
        services.AddTransient<DeleteOrganizationIntegrationEventHandler>();

        return services;
    }
}
