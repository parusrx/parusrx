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

            var documentTypesResponse = await httpClient.GetFromJsonAsync("api/v1/documentTypes", AppJsonSerializerContext.Default.DocumentTypesResponse);
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

/// <summary>
/// The document type item.
/// </summary>
/// <param name="Id">The document type identifier.</param>
/// <param name="Name">The document type name.</param>
/// <param name="Visible">The document type visibility.</param>
/// <param name="System">The document type system.</param>
/// <param name="ExternalId">The document type external identifier.</param>
/// <param name="Version">The document type version.</param>
public sealed record DocumentTypeItem(string Id, string Name, bool Visible, bool System, string? ExternalId, int Version);

/// <summary>
/// The document types request.
/// </summary>
[XmlRoot("documentTypesRequest")]
public sealed record DocumentTypesRequest
{
    /// <summary>
    /// Gets or sets the URL.
    /// </summary>
    [XmlElement("url")]
    public required string Url { get; init; }

    /// <summary>
    /// Gets or sets the API token.
    /// </summary>
    [XmlElement("apiToken")]
    public required string ApiToken { get; init; }
}

/// <summary>
/// The document types response.
/// </summary>
public sealed record DocumentTypesResponse
{
    /// <summary>
    /// Gets or sets the result.
    /// </summary>
    public bool Result { get; init; }

    /// <summary>
    /// Gets or sets the document types.
    /// </summary>
    public IEnumerable<DocumentTypeItem>? DocumentTypes { get; init; }
}

/// <summary>
/// The document type DTO.
/// </summary>
public sealed record DocumentTypeDto
{
    /// <summary>
    /// Gets or sets the document type identifier.
    /// </summary>
    [XmlAttribute("id")]
    public string Id { get; init; } = default!;

    /// <summary>
    /// Gets or sets the document type name.
    /// </summary>
    [XmlAttribute("name")]
    public string Name { get; init; } = default!;

    /// <summary>
    /// Gets or sets the document type visibility.
    /// </summary>
    [XmlAttribute("visible")]
    public bool Visible { get; init; }
}

/// <summary>
/// The document types DTO.
/// </summary>
[XmlRoot("documentTypes")]
public sealed record DocumentTypesDto
{
    /// <summary>
    /// Gets or sets the document types.
    /// </summary>
    [XmlElement("documentType")]
    public List<DocumentTypeDto> DocumentTypes { get; init; } = new();
}

/// <summary>
/// The document type item extensions.
/// </summary>
internal static class DocumentTypeItemExtensions
{
    /// <summary>
    /// Converts the document type item to document type DTO.
    /// </summary>
    /// <param name="documentTypeItem">The document type item.</param>
    /// <returns>The document type DTO.</returns>
    public static DocumentTypeDto AsDocumentTypeDto(this DocumentTypeItem documentTypeItem)
        => new()
        {
            Id = documentTypeItem.Id,
            Name = documentTypeItem.Name,
            Visible = documentTypeItem.Visible
        };
}

/// <summary>
/// The document type items extensions.
/// </summary>
internal static class DocumentTypeItemsExtensions
{
    /// <summary>
    /// Converts the document type items to document types DTO.
    /// </summary>
    /// <param name="documentTypeItems">The document type items.</param>
    /// <returns>The document types DTO.</returns>
    public static DocumentTypesDto AsDocumentTypesDto(this IEnumerable<DocumentTypeItem> documentTypeItems)
    {
        var documentTypesDto = new DocumentTypesDto();
        documentTypesDto.DocumentTypes.AddRange(documentTypeItems.Select(x => x.AsDocumentTypeDto()));
        return documentTypesDto;
    }
}

[JsonSourceGenerationOptions(
    GenerationMode = JsonSourceGenerationMode.Metadata, 
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, 
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(MqIntegrationEvent))]
[JsonSerializable(typeof(DocumentTypeItem))]
[JsonSerializable(typeof(DocumentTypesResponse))]
internal partial class AppJsonSerializerContext : JsonSerializerContext { }

public partial class Program { }