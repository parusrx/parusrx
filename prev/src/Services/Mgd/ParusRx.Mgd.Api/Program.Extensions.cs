// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Serilog;

public static partial class Program
{
    public const string AppName = "Mgd.Api";

    // <summary>
    /// Adds Serilog to the specified <see cref="WebApplicationBuilder"/>.
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/>.</param>
    public static void AddCustomSerilog(this WebApplicationBuilder builder)
    {
        var seqServerUrl = builder.Configuration["Serilog:SeqServerUrl"];
        var logstashUrl = builder.Configuration["Serilog:LogstashUrl"];

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .Enrich.WithProperty("ApplicationContext", AppName)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.Seq(string.IsNullOrWhiteSpace(seqServerUrl) ? "http://seq" : seqServerUrl)
            .WriteTo.Http(string.IsNullOrWhiteSpace(logstashUrl) ? "http://logstash:8080" : logstashUrl)
            .ReadFrom.Configuration(builder.Configuration)
            .CreateLogger();
    }

    /// <summary>
    /// Adds Health Check services to the specified <see cref="WebApplicationBuilder"/>.
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/>.</param>
    public static void AddCustomHealthCheck(this WebApplicationBuilder builder)
    {
        var hcBuilder = builder.Services.AddHealthChecks();

        hcBuilder.AddCheck("self", () => HealthCheckResult.Healthy());

        var provider = builder.Configuration["Database:Provider"];
        if (provider == "Oracle")
        {
            hcBuilder.AddOracle(
                builder.Configuration["Database:ConnectionString"],
                name: "Oracle Database Connection",
                tags: new string[] { "oracle" });
        }
        else if (provider == "Postgres")
        {
            hcBuilder.AddNpgSql(
                builder.Configuration["Database:ConnectionString"],
                name: "PostgreSQL Connection",
                tags: new string[] { "postgres" });
        }

        hcBuilder.AddUrlGroup(new Uri(builder.Configuration["Urls:Mgd"]), name: "MGD API Endpoint", tags: new string[] { "mgdapi" });
        hcBuilder.AddUrlGroup(new Uri(@$"{builder.Configuration["Urls:Cipher"]}\index.html"), name: "Cipher API Endpoint", tags: new string[] { "cipherapi" });
    }

    /// <summary>
    /// Adds Swagger services to the specified <see cref="WebApplicationBuilder"/>.
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/>.</param>
    public static void AddCustomSwagger(this WebApplicationBuilder builder) =>
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "MGD HTTP API",
                Version = "v1",
                Description = "The MGD Microservice HTTP API."
            });
        });

    /// <summary>
    /// Register the Swagger middleware.
    /// </summary>
    /// <param name="app">The <see cref="WebApplication"/>.</param>
    public static void UseCustomSwagger(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint($"/swagger/v1/swagger.json", "DaData API v1");
        });
    }

    /// <summary>
    /// Adds Data Access services to the specified <see cref="WebApplicationBuilder"/>.
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/>.</param>
    public static void AddCustomDataAccess(this WebApplicationBuilder builder)
    {
        var provider = builder.Configuration["Database:Provider"];

        if (provider == "Oracle")
        {
            builder.Services
                .AddDataAccess(options => options.UseOracle(builder.Configuration["Database:ConnectionString"]))
                .AddOracleParusRxStores();

            builder.Services.AddScoped<IDocumentStore, OracleDocumentStore>();
        }
        else if (provider == "Postgres")
        {
            builder.Services
                .AddDataAccess(options => options.UsePostgreSql(builder.Configuration["Database:ConnectionString"]))
                .AddPostgresParusRxStores();
        }

        builder.Services.AddScoped<ICredentialsStore, CredentialsStore>();
    }

    /// <summary>
    /// Configure the application options.
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/>.</param>
    public static void AddCustomOptions(this WebApplicationBuilder builder) =>
        builder.Services.Configure<UrlsSettings>(builder.Configuration.GetSection("Urls"));

    // <summary>
    /// Adds MVC services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddCustomMvc(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder
                .SetIsOriginAllowed((host) => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
        });

        return services;
    }

    /// <summary>
    /// Provides a common entry point for registering the application services.
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/>.</param>
    public static void AddCustomApplicationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpClient<ICipherService, CipherService>();
        builder.Services.AddHttpClient<IMgdService, MgdService>();

        builder.Services.TryAddScoped<IMessageHandler, MessageHandler>();
        builder.Services.TryAddScoped<IMessageService, MessageService>();
        builder.Services.TryAddScoped<IIdentityService, IdentityService>();
        builder.Services.TryAddScoped<IMgdIntegrationService, MgdIntegrationService>();
        builder.Services.AddScoped<IMgdIntegrationEventService, MgdIntegrationEventService>();

        builder.Services.AddTransient<MgdIntegrationEventHandler>();
    }
}
