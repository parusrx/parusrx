// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System;

using HealthChecks.UI.Client;

using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options => 
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, EmployeeRoleJsonSerializerContext.Default);
    options.SerializerOptions.TypeInfoResolverChain.Insert(1, DocumentTypeJsonSerializerContext.Default);
});

builder.Services.AddDaprClient();
builder.Services.AddDaprEventBus();

builder.Services.AddHttpClient();

builder.Services.AddHttpClient<IFileService, FileService>();
builder.Services.AddHttpClient<IDocumentService, DocumentService>();
builder.Services.AddHttpClient<IRouteTemplateService, RouteTemplateService>();
builder.Services.AddHttpClient<IApplicationTypeService, ApplicationTypeService>();
builder.Services.AddHttpClient<IApplicationGroupService, ApplicationGroupService>();
builder.Services.AddHttpClient<IApplicationPrintFormFileService, ApplicationPrintFormFileService>();

builder.Services.AddTransient<IAutoUpdateDocumentStatusService, OracleAutoUpdateDocumentStatusService>();
builder.Services.AddTransient<IAutoReceiveApplicationGroupService, OracleAutoReceiveApplicationGroupService>();
builder.Services.AddTransient<IAutoReceiveApplicationTypeService, OracleAutoReceiveApplicationTypeService>();
builder.Services.AddTransient<IAutoReceiveRouteTemplateService, OracleAutoReceiveRouteTemplateService>();

builder.Services.AddTransient<IBulkDataSyncTaskClient, BulkDataSyncTaskClient>();
builder.Services.AddTransient<DocumentTypeRequestIntegrationEventHandler>();
builder.Services.AddTransient<EmployeeRoleRequestIntegrationEventHandler>();
builder.Services.AddTransient<EmployeeRoleRequestIntegrationEventHandler>();
builder.Services.AddTransient<DepartmentBulkDataSyncTaskRequestIntegrationEventHandler>();
builder.Services.AddTransient<EmployeePositionBulkDataSyncTaskRequestIntegrationEventHandler>();
builder.Services.AddTransient<LegalEntityBulkDataSyncTaskRequestIntegrationEventHandler>();
builder.Services.AddTransient<UserBulkDataSyncTaskRequestIntegrationEventHandler>();
builder.Services.AddTransient<FilesUploadRequestIntegrationEventHandler>();
builder.Services.AddTransient<CreateDocumentGroupIntegrationEventHandler>();
builder.Services.AddTransient<SendToSigningIntegrationEventHandler>();
builder.Services.AddTransient<RouteTemplateRequestIntegrationEventHandler>();
builder.Services.AddTransient<ApplicationTypeRequestIntegrationEventHandler>();
builder.Services.AddTransient<ApplicationGroupIntegrationEventHandler>();
builder.Services.AddTransient<ApplicationPrintFormFileIntegrationEventHandler>();

// Data access
string provider = builder.Configuration["Database:Provider"] ?? string.Empty;
string connectionString = builder.Configuration["Database:ConnectionString"] ?? string.Empty;
switch (provider)
{
    case "Oracle":
        builder.Services
            .AddDataAccess(options => options.UseOracle(connectionString))
            .AddOracleParusRxStores();
        break;
    case "Postgres":
        builder.Services
            .AddDataAccess(options => options.UseNpgsql(connectionString))
            .AddPostgresParusRxStore();
        break;
    default:
        throw new NotSupportedException($"Database provider \"{provider}\" is not supported.");
}

builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy());

var app = builder.Build();

app.UseCloudEvents();
app.MapSubscribeHandler();

app.MapHealthChecks("/health", new HealthCheckOptions { Predicate = _ => true, ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse });
app.MapHealthChecks("/liveness", new HealthCheckOptions { Predicate = _ => _.Name.Contains("self") });

var pubsub = app.MapGroup("api/v1/pubsub");
const string DaprPubSubName = "pubsub";

pubsub.MapPost("/document-types", [Topic(DaprPubSubName, "DocumentTypeListIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] DocumentTypeRequestIntegrationEventHandler handler) => 
{
    await handler.HandleAsync(@event);
    return Results.Created();
});

pubsub.MapPost("/employee-roles", [Topic(DaprPubSubName, "EmployeeRoleListIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] EmployeeRoleRequestIntegrationEventHandler handler) => 
{
    await handler.HandleAsync(@event);
    return Results.Created();
});

pubsub.MapPost("/departments/bulk", [Topic(DaprPubSubName, "DepartmentListBulkDataSyncTaskIntegraionEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] DepartmentBulkDataSyncTaskRequestIntegrationEventHandler handler) => 
{
    await handler.HandleAsync(@event);
    return Results.Created();
});

pubsub.MapPost("/employee-positions/bulk", [Topic(DaprPubSubName, "EmployeePositionListBulkDataSyncTaskIntegraionEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] EmployeePositionBulkDataSyncTaskRequestIntegrationEventHandler handler) => 
{
    await handler.HandleAsync(@event);
    return Results.Created();
});

pubsub.MapPost("/legal-entities/bulk", [Topic(DaprPubSubName, "LegalEntityListBulkDataSyncTaskIntegraionEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] LegalEntityBulkDataSyncTaskRequestIntegrationEventHandler handler) => 
{
    await handler.HandleAsync(@event);
    return Results.Created();
});

pubsub.MapPost("/users/bulk", [Topic(DaprPubSubName, "UserListBulkDataSyncTaskIntegraionEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] UserBulkDataSyncTaskRequestIntegrationEventHandler handler) => 
{
    await handler.HandleAsync(@event);
    return Results.Created();
});

pubsub.MapPost("/files", [Topic(DaprPubSubName, "FilesUploadRequestIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] FilesUploadRequestIntegrationEventHandler handler) => 
{
    await handler.HandleAsync(@event);
    return Results.Created();
});

pubsub.MapPost("/document-groups", [Topic(DaprPubSubName, "CreateDocumentGroupIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] CreateDocumentGroupIntegrationEventHandler handler) => 
{
    await handler.HandleAsync(@event);
    return Results.Created();
});

pubsub.MapPost("/document-groups/send-to-signing", [Topic(DaprPubSubName, "SendToSigningIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] SendToSigningIntegrationEventHandler handler) =>
{
    await handler.HandleAsync(@event);
    return Results.Created();
});

pubsub.MapPost("/route-templates", [Topic(DaprPubSubName, "RouteTemplateListIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] RouteTemplateRequestIntegrationEventHandler handler) =>
{
    await handler.HandleAsync(@event);
    return Results.Created();
});

pubsub.MapPost("/application-types", [Topic(DaprPubSubName, "ApplicationTypeListIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] ApplicationTypeRequestIntegrationEventHandler handler) =>
{
    await handler.HandleAsync(@event);
    return Results.Created();
});

pubsub.MapPost("/application-groups", [Topic(DaprPubSubName, "ApplicationGroupListIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] ApplicationGroupIntegrationEventHandler handler) =>
{
    await handler.HandleAsync(@event);
    return Results.Created();
});

pubsub.MapPost("/application-print-form-file", [Topic(DaprPubSubName, "ApplicationPrintFormFileIntegrationEvent")] async ([FromBody] MqIntegrationEvent @event, [FromServices] ApplicationPrintFormFileIntegrationEventHandler handler) =>
{
    await handler.HandleAsync(@event);
    return Results.Created();
});

app.MapPost("/auto-update-document", async ([FromServices] IAutoUpdateDocumentStatusService autoUpdaterDocument) =>
{
    await autoUpdaterDocument.ExecuteAsync();
    return Results.Created();
});

app.MapPost("/auto-receive-application-group", async ([FromServices] IAutoReceiveApplicationGroupService autoReceiveApplicationGroup) =>
{
    await autoReceiveApplicationGroup.ExecuteAsync();
    return Results.Created();
});

app.MapPost("/auto-receive-application-type", async ([FromServices] IAutoReceiveApplicationTypeService autoReceiveApplicationType) =>
{
    await autoReceiveApplicationType.ExecuteAsync();
    return Results.Created();
});

app.MapPost("/auto-receive-route-template", async ([FromServices] IAutoReceiveRouteTemplateService autoReceiveRouteTemplate) =>
{
    await autoReceiveRouteTemplate.ExecuteAsync();
    return Results.Created();
});

app.Run();

public partial class Program { }