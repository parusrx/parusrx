// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Microsoft.Extensions.DependencyInjection;

public static class StaffServiceCollectionExtensions
{
    public static IServiceCollection AddStaff(this IServiceCollection services) 
    {
        services.AddHttpClient<IStaffService, StaffService>()
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler 
            { 
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
            })
            .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddTransient<GetStaffIntegrationEventHandler>();
        services.AddTransient<GetByEntityStaffIntegrationEventHandler>();
        services.AddTransient<CreateStaffIntegrationEventHandler>();
        services.AddTransient<UpdateStaffIntegrationEventHandler>();
        services.AddTransient<DeleteStaffIntegrationEventHandler>();

        return services;
    }
}