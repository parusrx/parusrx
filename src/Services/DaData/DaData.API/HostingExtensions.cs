// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Dapr;

using Evolve.Data.Oracle;
using Evolve.Data.PostgreSQL;

using ParusRx.DaData.API.Integration;
using ParusRx.DaData.API.Integration.Handlers;

namespace ParusRx.DaData.API;

/// <summary>
/// Represents hosting extensions.
/// </summary>
internal static class HostingExtensions
{
    /// <summary>
    /// Application name.
    /// </summary>
    public const string AppName = "DaData.Api";

    private const string CORS_POLICY = "CorsPolicy";

    /// <summary>
    /// Configure services.
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/>.</param>
    /// <returns>The <see cref="WebApplication"/>.</returns>
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddDaprClient();

        // Application settings
        builder.Services.Configure<DaDataSettings>(builder.Configuration.GetSection("URLs"));

        // Event bus
        builder.Services.AddScoped<IEventBus, DaprEventBus>();

        // Application specified services
        builder.Services.AddHttpClient<ISuggestPartyService, SuggestPartyService>();
        builder.Services.AddScoped<ISuggestPartyIntegrationEventService, SuggestPartyIntegrationEventService>();
        builder.Services.AddTransient<SuggestPartyIntegrationEventHandler>();

        // Data access
        var provider = builder.Configuration["Database:Provider"];

        switch (provider)
        {
            case "Oracle":
#pragma warning disable CS8604 // Possible null reference argument.
                builder.Services
                    .AddEvolveDataAccess(options => options.UseOracle(builder.Configuration["Database:ConnectionString"]))
                    .AddOracleParusRxStores();
#pragma warning restore CS8604 // Possible null reference argument.
                break;
            case "Postgres":
#pragma warning disable CS8604 // Possible null reference argument.
                builder.Services
                    .AddEvolveDataAccess(options => options.UsePostgreSql(builder.Configuration["Database:ConnectionString"]))
                    .AddPostgresParusRxStore();
#pragma warning restore CS8604 // Possible null reference argument.
                break;
            default:
                throw new NotSupportedException($"Database provider {provider} is not supported.");
        }

        // CORS
        builder.Services.AddCors(options =>
            options.AddPolicy(name: CORS_POLICY,
                corsPolicyBuilder =>
                {
                    corsPolicyBuilder.SetIsOriginAllowed((host) => true);
                    corsPolicyBuilder.AllowAnyMethod();
                    corsPolicyBuilder.AllowAnyHeader();
                    corsPolicyBuilder.AllowCredentials();
                }));

        // Swagger
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = $"Parus RX - {AppName}", Version = "v1" });

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        // Health checks
        builder.Services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy());

        return builder.Build();
    }

    /// <summary>
    /// Configure pipeline.
    /// </summary>
    /// <param name="app">The <see cref="WebApplication"/>.</param>
    /// <returns>The <see cref="WebApplication"/>.</returns>
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        // This middleware displays detailed error information in the browser when an exception occurs during development, 
        // making it easier for developers to debug their applications.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        // CORS
        app.UseCors(CORS_POLICY);

        // Swagger
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{AppName} v1"));

        app.UseCloudEvents();

        app.MapSubscribeHandler();

        // Redirect to swagger
        app.MapGet("/", () => Results.LocalRedirect("~/swagger")).ExcludeFromDescription();

        // Health checks
        app.MapHealthChecks("/health", new HealthCheckOptions
        {
            Predicate = _ => true
        })
        .WithOpenApi();

        // Liveness probe
        app.MapHealthChecks("/liveness", new HealthCheckOptions
        {
            Predicate = r => r.Name.Contains("self")
        })
        .WithOpenApi();


        app.MapPost("/api/v1/suggestions", [Topic("pubsub", "DaDataSuggestionsFindByIdPartyIntegrationEvent")] async (IntegrationEvent @event, IServiceProvider serviceProvider) =>
        {
            var handler = serviceProvider.GetRequiredService<SuggestPartyIntegrationEventHandler>();
            await handler.HandleAsync(@event);
            return Results.Ok();
        });

        return app;
    }
}
