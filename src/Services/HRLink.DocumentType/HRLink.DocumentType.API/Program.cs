// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Text.Json.Serialization;
using System.Xml.Serialization;

using Dapr;

using Evolve.Data.Oracle;
using Evolve.Data.PostgreSQL;

using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

using ParusRx.EventBus.Events;
using ParusRx.Storage;
using ParusRx.Storage.Oracle;
using ParusRx.Storage.Postgres;
using ParusRx.Xml;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

builder.Services.AddDaprClient();
builder.Services.AddDaprEventBus();

builder.Services.AddHttpClient();

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
app.MapHealthChecks("/liveness", new HealthCheckOptions { Predicate = r => r.Name.Contains("self") });

app.MapPost("api/v1/documentTypes", [Topic("pubsub", "DocumentTypesIntegrationEvent")] async (MqIntegrationEvent @event, IHttpClientFactory httpClientFactory, IParusRxStore store) =>
{
    app.Logger.LogInformation("Handling integration event: {IntegrationEventId} - {IntegrationEvent}", @event.Id, @event);
    
    string id = @event.Body;
    try
    {
        byte[] data = await store.ReadDataRequestAsync(id);
        var documentTypesRequest = XmlSerializerUtility.Deserialize<DocumentTypesRequest>(data);
        if (documentTypesRequest is not null)
        {
            var httpClient = httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(documentTypesRequest.Url);
            httpClient.DefaultRequestHeaders.Add("User-Api-Token", documentTypesRequest.ApiToken);

            var documentTypesResponse = await httpClient.GetFromJsonAsync<DocumentTypesResponse>("api/v1/documentTypes");
            var documentTypesDto = documentTypesResponse?.DocumentTypes?.AsDocumentTypesDto();
            if (documentTypesDto is not null)
            {
                byte[]? response = XmlSerializerUtility.Serialize(documentTypesDto);
                if (response is not null)
                {
                    await store.SaveDataResponseAsync(id, response);
                }
            }
        }
    }
    catch (Exception ex)
    {
        await store.ErrorAsync(id, ex.Message);
        app.Logger.LogError(ex, "Error while processing integration event {IntegrationEventId} of type {IntegrationEventType}: {Message}", @event.Id, @event.GetType().Name, ex.Message);
    }

    return TypedResults.Created();
});

app.Run();

public sealed record DocumentTypeItem(string Id, string Name, bool Visible, bool System, string? ExternalId, int Version);

[XmlRoot("documentTypesRequest")]
public sealed record DocumentTypesRequest
{
    [XmlElement("url")]
    public required string Url { get; set; }
    [XmlElement("apiToken")]
    public required string ApiToken { get; set; }
}

public sealed record DocumentTypesResponse
{
    public required bool Result { get; set; }
    public required IEnumerable<DocumentTypeItem> DocumentTypes { get; set; } = Enumerable.Empty<DocumentTypeItem>();
}

public class DocumentTypeDto
{
    [XmlAttribute("id")]
    public string Id { get; set; } = default!;
    [XmlAttribute("name")]
    public string Name { get; set; } = default!;
    [XmlAttribute("visible")]
    public bool Visible { get; set; }
    [XmlAttribute("system")]
    public bool System { get; set; }
    [XmlAttribute("externalId")]
    public string? ExternalId { get; set; }
    [XmlAttribute("version")]
    public int Version { get; set; }
}

[XmlRoot("documentTypes")]
public class DocumentTypesDto
{
    [XmlElement("documentType")]
    public List<DocumentTypeDto> DocumentTypes { get; set; } = new();
}

internal static class DocumentTypeItemExtensions
{
    public static DocumentTypeDto AsDocumentTypeDto(this DocumentTypeItem documentTypeItem)
        => new()
        {
            Id = documentTypeItem.Id,
            Name = documentTypeItem.Name,
            Visible = documentTypeItem.Visible,
            System = documentTypeItem.System,
            ExternalId = documentTypeItem.ExternalId,
            Version = documentTypeItem.Version
        };
}

internal static class DocumentTypeItemsExtensions
{
    public static DocumentTypesDto AsDocumentTypesDto(this IEnumerable<DocumentTypeItem> documentTypeItems)
    {
        var documentTypesDto = new DocumentTypesDto();
        documentTypesDto.DocumentTypes.AddRange(documentTypeItems.Select(x => x.AsDocumentTypeDto()));
        return documentTypesDto;
    }
}

[JsonSerializable(typeof(MqIntegrationEvent))]
[JsonSerializable(typeof(DocumentTypeItem))]
[JsonSerializable(typeof(DocumentTypeItem[]))]
[JsonSerializable(typeof(DocumentTypesResponse))]
internal partial class AppJsonSerializerContext : JsonSerializerContext { }

public partial class Program { }