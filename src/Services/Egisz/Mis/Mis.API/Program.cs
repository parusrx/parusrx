// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using HealthChecks.UI.Client;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddDistributedMemoryCache();

builder.Services.AddHttpResponseExceptionHandler();

builder.Services.AddIpsIdentityProvider(builder.Configuration);
builder.Services.AddFrmo(builder.Configuration["Egisz:Url"] ?? string.Empty);
builder.Services.AddFrmr(builder.Configuration["Egisz:Url"] ?? string.Empty);

builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy());

var app = builder.Build();

app.UseExceptionHandler(options => { });

app.MapHealthChecks("/health", new HealthCheckOptions { Predicate = _ => true, ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse });
app.MapHealthChecks("/liveness", new HealthCheckOptions { Predicate = r => r.Name.Contains("self") });

app.MapGroup("/org")
    .WithTags("Organization API")
    .MapOrganizationApi();

app.MapGroup("/person")
    .WithTags("Person API")
    .MapPersonApi();

app.Run();