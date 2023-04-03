// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using ParusRX.Api.Gateway.MqEndpoints;

namespace ParusRX.Api.Gateway;

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

        builder.Services.AddScoped<IEventBus, DaprEventBus>();

        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = $"Parus RX - {AppName}", Version = "v1" });

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

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

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"Parus RX - {AppName} V1"));

        app.UseCloudEvents();

        app.MapSubscribeHandler();

        // Redirect to swagger
        app.MapGet("/", () => Results.LocalRedirect("~/swagger")).ExcludeFromDescription();

        // Health checks
        app.MapHealthChecks("/hc", new HealthCheckOptions
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        // Liveness probe
        app.MapHealthChecks("/liveness", new HealthCheckOptions
        {
            Predicate = r => r.Name.Contains("self")
        });

        // Publish integration event
        app.MapGroup("/api/v1/mq")
            .MapMqEndpoint()
            .WithTags("MQ API");

        return app;
    }
}