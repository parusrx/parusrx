// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddAuthorizationHttpClient();

builder.Services.AddApplicationOptions(builder.Configuration);

builder.Services.AddHttpResponseExceptionHandler();

builder.Services.AddIpsIdentityProvider();
builder.Services.AddApplicationHttpClients();

builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy());

var app = builder.Build();

app.UseExceptionHandler(options => { });

app.MapHealthChecks("/health", new HealthCheckOptions { Predicate = _ => true });
app.MapHealthChecks("/liveness", new HealthCheckOptions { Predicate = r => r.Name.Contains("self") });

app.MapPersons();
app.MapOrganizations();

app.Run();