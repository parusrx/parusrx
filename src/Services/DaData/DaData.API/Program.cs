﻿// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Dapr;

using Evolve.Data.Oracle;
using Evolve.Data.PostgreSQL;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddDaprClient();
builder.Services.AddDaprEventBus();

builder.Services.Configure<DaDataSettings>(builder.Configuration.GetSection("URLs"));

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

// Health Checks
builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy());

var app = builder.Build();

app.UseCloudEvents();
app.MapSubscribeHandler();

app.MapHealthChecks("/health", new HealthCheckOptions { Predicate = _ => true });
app.MapHealthChecks("/liveness", new HealthCheckOptions { Predicate = r => r.Name.Contains("self") });

app.MapPost("/api/v1/suggestions", [Topic("pubsub", "DaDataSuggestionsFindByIdPartyIntegrationEvent")] async (MqIntegrationEvent @event, SuggestPartyIntegrationEventHandler handler) =>
{
    await handler.HandleAsync(@event);
    return Results.Created();
});

app.Run();