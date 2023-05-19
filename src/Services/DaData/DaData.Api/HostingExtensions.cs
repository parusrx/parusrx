// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DaData.Api;

/// <summary>
/// Represents hosting extensions.
/// </summary>
internal static class HostingExtensions
{
    /// <summary>
    /// Application name.
    /// </summary>
    public const string AppName = "DaData.Api";

    /// <summary>
    /// Configure services.
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/>.</param>
    /// <returns>The <see cref="WebApplication"/>.</returns>
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddDaprClient();

        // Event bus
        builder.Services.AddScoped<IEventBus, DaprEventBus>();

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

        // Swagger
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{AppName} v1"));

        app.UseCloudEvents();

        app.MapSubscribeHandler();

        app.UseEndpoints(endpoints =>
        {
            // Redirect to swagger
            endpoints.MapGet("/", () => Results.LocalRedirect("~/swagger")).ExcludeFromDescription();

            // Health checks
            endpoints.MapHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            })
            .WithOpenApi();

            // Liveness probe
            endpoints.MapHealthChecks("/liveness", new HealthCheckOptions
            {
                Predicate = r => r.Name.Contains("self")
            })
            .WithOpenApi();
        });

        return app;
    }
}
