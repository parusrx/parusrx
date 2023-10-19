// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Microsoft.Extensions.DependencyInjection;

public static class DepartmentServiceCollectionExtensions
{
    public static IServiceCollection AddDepartment(this IServiceCollection services) 
    {
        services.AddHttpClient<IDepartmentService, DepartmentService>()
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler 
            { 
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
            })
            .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddTransient<GetByOidDepartmentIntegrationEventHandler>();
        services.AddTransient<ListPagedDepartmentIntegrationEventHandler>();
        services.AddTransient<CreateDepartmentIntegrationEventHandler>();
        services.AddTransient<UpdateDepartmentIntegrationEventHandler>();
        services.AddTransient<DeleteDepartmentIntegrationEventHandler>();

        return services;
    }
}
