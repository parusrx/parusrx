// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddHealthChecksUI()
    .AddInMemoryStorage();

builder.Logging.AddJsonConsole();

var app = builder.Build();

var pathBase = app.Configuration["PATH_BASE"];
if (!string.IsNullOrEmpty(pathBase))
{
    app.UsePathBase(pathBase);
}

app.UseHealthChecksUI(config => 
{
    config.ResourcesPath = string.IsNullOrEmpty(pathBase) 
        ? "/ui/resources" 
        : $"{pathBase}/ui/resources";
    config.AddCustomStylesheet("wwwroot/css/main.css");
});

app.MapGet(string.IsNullOrEmpty(pathBase)
    ? "/"
    : pathBase, () => Results.LocalRedirect("~/healthchecks-ui"));
app.MapHealthChecksUI();

app.Run();
