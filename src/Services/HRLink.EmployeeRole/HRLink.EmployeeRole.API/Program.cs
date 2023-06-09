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
        builder.Services
            .AddEvolveDataAccess(options => options.UseOracle(connectionString))
            .AddOracleParusRxStores();
        break;
    case "Postgres":
        builder.Services
            .AddEvolveDataAccess(options => options.UsePostgreSql(connectionString))
            .AddPostgresParusRxStore();
        break;
    default:
        throw new NotSupportedException($"Database provider {provider} is not supported.");
}

builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy());

var app = builder.Build();

app.UseCloudEvents();
app.MapSubscribeHandler();

app.MapHealthChecks("/health", new HealthCheckOptions { Predicate = _ => true});
app.MapHealthChecks("/liveness", new HealthCheckOptions { Predicate = r => r.Name.Contains("self") });

app.MapPost("api/v1/employeeRoles", [Topic("pubsub", "EmployeeRolesIntegrationEvent")] async (MqIntegrationEvent @event, IHttpClientFactory httpClientFactory, IParusRxStore store) =>
{
    app.Logger.LogInformation("Handling integration event: {IntegrationEventId} - {IntegrationEvent}", @event.Id, @event);

    string id = @event.Body;
    try
    {
        byte[] data = await store.ReadDataRequestAsync(id);
        var employeeRolesRequest = XmlSerializerUtility.Deserialize<EmployeeRolesRequest>(data);
        if (employeeRolesRequest is not null)
        {
            var httpClient = httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(employeeRolesRequest.Url);
            httpClient.DefaultRequestHeaders.Add("User-Api-Token", employeeRolesRequest.ApiToken);

            var employeeRolesResponse = await httpClient.GetFromJsonAsync("api/v1/employeeRoles", AppJsonSerializerContext.Default.EmployeeRolesResponse);
            var employeeRolesDto = employeeRolesResponse?.EmployeeRoles?.AsEmployeeRolesDto();
            if (employeeRolesDto is not null)
            {
                byte[]? response = XmlSerializerUtility.Serialize(employeeRolesDto);
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
/// The employee role item.
/// </summary>
/// <param name="Id">The employee role identifier.</param>
/// <param name="Name">The employee role name.</param>
/// <param name="Description">The employee role description.</param>
public sealed record EmployeeRoleItem(string Id, string Name, string Description);

/// <summary>
/// The employee role DTO.
/// </summary>
public sealed record EmployeeRoleDto 
{
    /// <summary>
    /// Gets or sets the employee role identifier.
    /// </summary>
    [XmlAttribute("id")]
    public string Id { get; init; } = default!;

    /// <summary>
    /// Gets or sets the employee role name.
    /// </summary>
    [XmlAttribute("name")]
    public string Name { get; init; } = default!;

    /// <summary>
    /// Gets or sets the employee role description.
    /// </summary>
    [XmlAttribute("description")]
    public string Description { get; init; } = default!;
}

/// <summary>
/// The employee roles DTO.
/// </summary>
[XmlRoot("employeeRoles")]
public sealed record EmployeeRolesDto
{
    /// <summary>
    /// Gets or sets the employee roles.
    /// </summary>
    [XmlElement("employeeRole")]
    public List<EmployeeRoleDto> EmployeeRoles { get; init; } = new();
}

/// <summary>
/// The employee roles request.
/// </summary>
[XmlRoot("employeeRolesRequest")]
public sealed record EmployeeRolesRequest
{
    /// <summary>
    /// Gets or sets the URL.
    /// </summary>
    [XmlElement("url")]
    public required string Url { get; init; } = default!;

    /// <summary>
    /// Gets or sets the API token.
    /// </summary>
    [XmlElement("apiToken")]
    public required string ApiToken { get; init; } = default!;
}

/// <summary>
/// The employee roles response.
/// </summary>
public sealed record EmployeeRolesResponse 
{
    /// <summary>
    /// Gets or sets the result.
    /// </summary>
    public bool Result { get; init; }

    /// <summary>
    /// Gets or sets the employee roles.
    /// </summary>
    public IEnumerable<EmployeeRoleItem>? EmployeeRoles { get; init; }
}

/// <summary>
/// The employee role item extensions.
/// </summary>
internal static class EmployeeRoleItemExtensions 
{
    /// <summary>
    /// Converts the employee role item to the employee role DTO.
    /// </summary>
    /// <param name="employeeRoleItem">The employee role item.</param>
    /// <returns>The employee role DTO.</returns>
    public static EmployeeRoleDto AsEmployeeRoleDto(this EmployeeRoleItem employeeRoleItem)
        => new()
        {
            Id = employeeRoleItem.Id,
            Name = employeeRoleItem.Name,
            Description = employeeRoleItem.Description
        };
}

/// <summary>
/// The employee role items extensions.
/// </summary>
internal static class EmployeeRoleItemsExtensions
{
    /// <summary>
    /// Converts the employee role items to the employee roles DTO.
    /// </summary>
    /// <param name="employeeRoleItems">The employee role items.</param>
    /// <returns>The employee roles DTO.</returns>
    public static EmployeeRolesDto AsEmployeeRolesDto(this IEnumerable<EmployeeRoleItem> employeeRoleItems)
    {
        var employeeRolesDto = new EmployeeRolesDto();
        employeeRolesDto.EmployeeRoles.AddRange(employeeRoleItems.Select(x => x.AsEmployeeRoleDto()));
        return employeeRolesDto;
    }
}

[JsonSourceGenerationOptions(
    GenerationMode = JsonSourceGenerationMode.Metadata,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(MqIntegrationEvent))]
[JsonSerializable(typeof(EmployeeRoleItem))]
[JsonSerializable(typeof(EmployeeRolesResponse))]
internal partial class AppJsonSerializerContext : JsonSerializerContext { }

public partial class Program { }