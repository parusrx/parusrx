// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("Starting up...");

try
{
    const string AppName = "Gateway";

    var builder = WebApplication.CreateSlimBuilder(args);

    builder.Host.UseSerilog((ctx, lc) => lc
        .ReadFrom.Configuration(ctx.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}"));

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

    var app = builder.Build();

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

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly.");
}
finally
{
    Log.Information("Shutting down.");
    Log.CloseAndFlush();
}

public partial class Program { }