// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddIntegrationEventHandlers(this IServiceCollection services)
    {
        services.AddTransient<GetPersonIntegrationEventHandler>();
        services.AddTransient<ListPagedPersonIntegrationEventHandler>();
        services.AddTransient<CreatePersonIntegrationEventHandler>();
        services.AddTransient<UpdatePersonIntegrationEventHandler>();
        services.AddTransient<DeletePersonIntegrationEventHandler>();

        services.AddTransient<GetMilitaryServiceIntegrationEventHandler>();
        services.AddTransient<CreateMilitaryServiceIntegrationEventHandler>();
        services.AddTransient<UpdateMilitaryServiceIntegrationEventHandler>();
        services.AddTransient<DeleteMilitaryServiceIntegrationEventHandler>();

        services.AddTransient<ListResolutionIntegrationEventHandler>();

        services.AddTransient<GetEducationCommonIntegrationEventHandler>();
        services.AddTransient<CreateEducationCommonIntegrationEventHandler>();
        services.AddTransient<UpdateEducationCommonIntegrationEventHandler>();
        services.AddTransient<DeleteEducationCommonIntegrationEventHandler>();

        services.AddTransient<GetEducationProfIntegrationEventHandler>();
        services.AddTransient<CreateEducationProfIntegrationEventHandler>();
        services.AddTransient<UpdateEducationProfIntegrationEventHandler>();
        services.AddTransient<DeleteEducationProfIntegrationEventHandler>();

        services.AddTransient<ListEducationPostgraduateIntegrationEventHandler>();
        services.AddTransient<CreateEducationPostgraduateIntegrationEventHandler>();
        services.AddTransient<UpdateEducationPostgraduateIntegrationEventHandler>();
        services.AddTransient<DeleteEducationPostgraduateIntegrationEventHandler>();

        services.AddTransient<ListPagedEducationExtIntegrationEventHandler>();
        services.AddTransient<CreateEducationExtIntegrationEventHandler>();
        services.AddTransient<UpdateEducationExtIntegrationEventHandler>();
        services.AddTransient<DeleteEducationExtIntegrationEventHandler>();

        services.AddTransient<ListEducationCertIntegrationEventHandler>();
        services.AddTransient<CreateEducationCertIntegrationEventHandler>();
        services.AddTransient<UpdateEducationCertIntegrationEventHandler>();
        services.AddTransient<DeleteEducationCertIntegrationEventHandler>();

        services.AddTransient<GetPersonAccreditationIntegrationEventHandler>();

        services.AddTransient<ListPersonQualificationIntegrationEventHandler>();
        services.AddTransient<CreatePersonQualificationIntegrationEventHandler>();
        services.AddTransient<UpdatePersonQualificationIntegrationEventHandler>();
        services.AddTransient<DeletePersonQualificationIntegrationEventHandler>();

        services.AddTransient<ListPersonCardIntegrationEventHandler>();
        services.AddTransient<CreatePersonCardIntegrationEventHandler>();
        services.AddTransient<UpdatePersonCardIntegrationEventHandler>();
        services.AddTransient<DeletePersonCardIntegrationEventHandler>();

        services.AddTransient<ListPersonNominationIntegrationEventHandler>();
        services.AddTransient<CreatePersonNominationIntegrationEventHandler>();
        services.AddTransient<UpdatePersonNominationIntegrationEventHandler>();
        services.AddTransient<DeletePersonNominationIntegrationEventHandler>();

        services.AddTransient<ListPersonOrganizationIntegrationEventHandler>();
        services.AddTransient<CreatePersonOrganizationIntegrationEventHandler>();
        services.AddTransient<UpdatePersonOrganizationIntegrationEventHandler>();
        services.AddTransient<DeletePersonOrganizationIntegrationEventHandler>();

        services.AddTransient<GetFullPersonIntegrationEventHandler>();

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
