// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddIntegrationEventHandlers(this IServiceCollection services)
    {
        services.AddTransient<ListPagedOrganizationIntegrationEventHandler>();
        services.AddTransient<GetOrganizationIntegrationEventHandler>();
        services.AddTransient<UpdateOrganizationIntegrationEventHandler>();
        services.AddTransient<DeleteOrganizationIntegrationEventHandler>();

        services.AddTransient<GetDepartmentIntegrationEventHandler>();
        services.AddTransient<ListPagedDepartmentIntegrationEventHandler>();
        services.AddTransient<CreateDepartmentIntegrationEventHandler>();
        services.AddTransient<UpdateDepartmentIntegrationEventHandler>();
        services.AddTransient<DeleteDepartmentIntegrationEventHandler>();

        services.AddTransient<ListBuildingIntegrationEventHandler>();
        services.AddTransient<GetBuildingIntegrationEventHandler>();
        services.AddTransient<CreateBuildingIntegrationEventHandler>();
        services.AddTransient<UpdateBuildingIntegrationEventHandler>();
        services.AddTransient<DeleteBuildingIntegrationEventHandler>();

        services.AddTransient<ListTpggIntegrationEventHandler>();

        services.AddTransient<ListTerritorialDepartIntegrationEventHandler>();
        services.AddTransient<GetTerritorialDepartIntegrationEventHandler>();
        services.AddTransient<CreateTerritorialDepartIntegrationEventHandler>();
        services.AddTransient<UpdateTerritorialDepartIntegrationEventHandler>();
        services.AddTransient<DeleteTerritorialDepartIntegrationEventHandler>();

        services.AddTransient<ListAirAmbulanceIntegrationEventHandler>();
        services.AddTransient<GetAirAmbulanceIntegrationEventHandler>();
        services.AddTransient<CreateAirAmbulanceIntegrationEventHandler>();
        services.AddTransient<UpdateAirAmbulanceIntegrationEventHandler>();
        services.AddTransient<DeleteAirAmbulanceIntegrationEventHandler>();

        services.AddTransient<ListEquipmentIntegrationEventHandler>();
        services.AddTransient<GetEquipmentIntegrationEventHandler>();
        services.AddTransient<CreateEquipmentIntegrationEventHandler>();
        services.AddTransient<UpdateEquipmentIntegrationEventHandler>();
        services.AddTransient<DeleteEquipmentIntegrationEventHandler>();

        services.AddTransient<ListMobileDepartIntegrationEventHandler>();
        services.AddTransient<GetMobileDepartIntegrationEventHandler>();
        services.AddTransient<CreateMobileDepartIntegrationEventHandler>();
        services.AddTransient<UpdateMobileDepartIntegrationEventHandler>();
        services.AddTransient<DeleteMobileDepartIntegrationEventHandler>();

        services.AddTransient<ListHouseGroundIntegrationEventHandler>();
        services.AddTransient<GetHouseGroundIntegrationEventHandler>();
        services.AddTransient<CreateHouseGroundIntegrationEventHandler>();
        services.AddTransient<UpdateHouseGroundIntegrationEventHandler>();
        services.AddTransient<DeleteHouseGroundIntegrationEventHandler>();

        services.AddTransient<ListSiteIntegrationEventHandler>();
        services.AddTransient<GetSiteIntegrationEventHandler>();
        services.AddTransient<CreateSiteIntegrationEventHandler>();
        services.AddTransient<UpdateSiteIntegrationEventHandler>();
        services.AddTransient<DeleteSiteIntegrationEventHandler>();

        services.AddTransient<ListStaffIntegrationEventHandler>();
        services.AddTransient<GetStaffIntegrationEventHandler>();
        services.AddTransient<CreateStaffIntegrationEventHandler>();
        services.AddTransient<UpdateStaffIntegrationEventHandler>();
        services.AddTransient<DeleteStaffIntegrationEventHandler>();

        services.AddTransient<ListLicenseIntegrationEventHandler>();
        services.AddTransient<GetLicenseIntegrationEventHandler>();

        services.AddTransient<ListServiceInfoIntegrationEventHandler>();
        services.AddTransient<CreateServiceInfoIntegrationEventHandler>();
        services.AddTransient<UpdateServiceInfoIntegrationEventHandler>();
        services.AddTransient<DeleteServiceInfoIntegrationEventHandler>();

        services.AddTransient<ListTelemedicineIntegrationEventHandler>();
        services.AddTransient<GetTelemedicineIntegrationEventHandler>();
        services.AddTransient<CreateTelemedicineIntegrationEventHandler>();
        services.AddTransient<UpdateTelemedicineIntegrationEventHandler>();
        services.AddTransient<DeleteTelemedicineIntegrationEventHandler>();

        services.AddTransient<ListEducationOrganizationDepartIntegrationEventHandler>();
        services.AddTransient<GetEducationOrganizationDepartIntegrationEventHandler>();
        services.AddTransient<CreateEducationOrganizationDepartIntegrationEventHandler>();
        services.AddTransient<UpdateEducationOrganizationDepartIntegrationEventHandler>();
        services.AddTransient<DeleteEducationOrganizationDepartIntegrationEventHandler>();

        return services;
    }

    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        string provider = configuration["Database:Provider"] ?? string.Empty;
        string connectionString = configuration["Database:ConnectionString"] ?? string.Empty;
        switch (provider)
        {
            case "Oracle":
                services
                    .AddDataAccess(options => options.UseOracle(connectionString))
                    .AddOracleParusRxStores();
                break;
            case "Postgres":
                services
                    .AddDataAccess(options => options.UseNpgsql(connectionString))
                    .AddPostgresParusRxStore();
                break;
            default:
                throw new NotSupportedException($"Database provider \"{provider}\" is not supported.");
        }

        return services;
    }
}
