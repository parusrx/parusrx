// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Gateway.API;

/// <summary>
/// Represents hosting extensions.
/// </summary>
internal static class HostingExtensions
{
    /// <summary>
    /// Application name.
    /// </summary>
    public const string AppName = "ApiGateway";

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
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"Parus RX - {AppName} v1"));

        app.UseCloudEvents();

        app.MapSubscribeHandler();

        // Redirect to swagger
        app.MapGet("/", () => Results.LocalRedirect("~/swagger")).ExcludeFromDescription();

        // Health checks
        app.MapHealthChecks("/health", new HealthCheckOptions
        {
            Predicate = _ => true
        });

        // Liveness probe
        app.MapHealthChecks("/liveness", new HealthCheckOptions
        {
            Predicate = r => r.Name.Contains("self")
        });

        // Publish integration event
        app.MapGroup("/api/v1/mq")
            .MapMqEndpoint()
            .WithTags("Message queue endpoints");

        return app;
    }
}