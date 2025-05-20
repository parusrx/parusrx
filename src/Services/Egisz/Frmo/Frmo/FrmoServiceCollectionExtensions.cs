// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection;

public static class FrmoServiceCollectionExtensions
{
    public static void AddFrmo(this IServiceCollection services, string uri) 
    {
        services.TryAddTransient<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IOrganizationService, OrganizationService>(options => options.BaseAddress = new Uri(uri))
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
            })
            .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IDepartmentService, DepartmentService>(options => options.BaseAddress = new Uri(uri))
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
            })
            .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IBuildingService, BuildingService>(options => options.BaseAddress = new Uri(uri))
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
            })
            .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<ITpggService, TpggService>(options => options.BaseAddress = new Uri(uri))
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
            })
            .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<ITerritorialDepartService, TerritorialDepartService>(options => options.BaseAddress = new Uri(uri))
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
            })
            .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IAirAmbulanceService, AirAmbulanceService>(options => options.BaseAddress = new Uri(uri))
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
            })
            .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IEquipmentService, EquipmentService>(options => options.BaseAddress = new Uri(uri))
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
            })
            .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IMobileDepartService, MobileDepartService>(options => options.BaseAddress = new Uri(uri))
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
            })
            .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IHouseGroundService, HouseGroundService>(options => options.BaseAddress = new Uri(uri))
           .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
           {
               ClientCertificateOptions = ClientCertificateOption.Manual,
               ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
           })
           .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<ISiteService, SiteService>(options => options.BaseAddress = new Uri(uri))
           .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
           {
               ClientCertificateOptions = ClientCertificateOption.Manual,
               ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
           })
           .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IStaffService, StaffService>(options => options.BaseAddress = new Uri(uri))
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
            })
            .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<ILicenseService, LicenseService>(options => options.BaseAddress = new Uri(uri))
           .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
           {
               ClientCertificateOptions = ClientCertificateOption.Manual,
               ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
           })
           .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IServiceInfoService, ServiceInfoService>(options => options.BaseAddress = new Uri(uri))
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
              })
              .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<ITelemedicineService, TelemedicineService>(options => options.BaseAddress = new Uri(uri))
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
              })
              .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IEducationOrganizationDepartService, EducationOrganizationDepartService>(options => options.BaseAddress = new Uri(uri))
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
              })
              .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IOrganizationOmsService, OrganizationOmsService>(options => options.BaseAddress = new Uri(uri))
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
              })
              .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IDepartmentOmsService, DepartmentOmsService>(options => options.BaseAddress = new Uri(uri))
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
              })
              .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
    }
}
