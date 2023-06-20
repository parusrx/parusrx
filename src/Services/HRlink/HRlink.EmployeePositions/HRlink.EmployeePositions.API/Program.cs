// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Evolve.Data.Oracle;
using Evolve.Data.PostgreSQL;

using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using ParusRx.Storage.Oracle;

using ParusRx.Storage.Postgres;

using ParusRx.Storage;
using ParusRx.HRlink.EmployeePositions.API;
using ParusRx.HRlink.Internal;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddDaprClient();
builder.Services.AddDaprEventBus();

builder.Services.AddHttpClient<IBulkDataSyncClient, BulkDataSyncClient>();

// Data access
string provider = builder.Configuration["Database:Provider"] ?? string.Empty;
string connectionString = builder.Configuration["Database:ConnectionString"] ?? string.Empty;
switch (provider)
{
    case "Oracle":
        builder.Services.AddEvolveDataAccess(options => options.UseOracle(connectionString));
        builder.Services.AddScoped<IParusRxStore, OracleParusRxStore>();
        break;
    case "Postgres":
        builder.Services.AddEvolveDataAccess(options => options.UsePostgreSql(connectionString));
        builder.Services.AddScoped<IParusRxStore, PostgresParusRxStore>();
        break;
    default:
        throw new NotSupportedException($"Database provider \"{provider}\" is not supported.");
}

builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy());

var app = builder.Build();

app.UseCloudEvents();
app.MapSubscribeHandler();

app.MapHealthChecks("/health", new HealthCheckOptions { Predicate = _ => true });
app.MapHealthChecks("/liveness", new HealthCheckOptions { Predicate = _ => _.Name.Contains("self") });

app.MapEmployeePositionApi();

app.Run();
