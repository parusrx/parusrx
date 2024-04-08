// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Handlers;

/// <summary>
/// The employee role request integration event handler.
/// </summary>
/// <param name="store">The Parus RX store.</param>
/// <param name="httpClientFactory">The HTTP client factory.</param>
/// <param name="logger">The logger.</param>
public sealed class EmployeeRoleRequestIntegrationEventHandler(IParusRxStore store, IHttpClientFactory httpClientFactory, ILogger<EmployeeRoleRequestIntegrationEventHandler> logger)
    : IIntegrationEventHandler<MqIntegrationEvent>
{
    /// <inheritdoc/>
    public async Task HandleAsync(MqIntegrationEvent @event, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Handling integration event: {IntegrationEventId} - {IntegrationEvent}", @event.Id, @event);

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

                var employeeRoles = await httpClient.GetFromJsonAsync("api/v1/employeeRoles", EmployeeRoleJsonSerializerContext.Default.EmployeeRolesResponse, cancellationToken: cancellationToken);
                if (employeeRoles is not null)
                {
                    byte[]? response = XmlSerializerUtility.Serialize(employeeRoles);
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

            logger.LogError(ex, "Error while processing integration event {IntegrationEventId} of type {IntegrationEventType}: {Message}", @event.Id, @event.GetType().Name, ex.Message);
        }
    }
}

/// <summary>
/// Represents a request of employee roles.
/// </summary>
[XmlRoot("employeeRolesRequest")]
public record EmployeeRolesRequest 
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
/// Represents a response of employee roles.
/// </summary>
[XmlRoot("employeeRolesResponse")]
public record EmployeeRolesResponse
{
    /// <summary>
    /// Gets or sets the result.
    /// </summary>
    [XmlElement("result")]
    [JsonPropertyName("result")]
    public required bool Result { get; init; }

    /// <summary>
    /// Gets or sets the employee roles.
    /// </summary>
    [XmlArray("employeeRoles")]
    [XmlArrayItem("employeeRole")]
    [JsonPropertyName("employeeRoles")]
    public required EmployeeRole[]? EmployeeRoles { get; init; }
}

[JsonSourceGenerationOptions(
    GenerationMode = JsonSourceGenerationMode.Metadata,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(MqIntegrationEvent))]
[JsonSerializable(typeof(EmployeeRole))]
[JsonSerializable(typeof(EmployeeRolesRequest))]
[JsonSerializable(typeof(EmployeeRolesResponse))]
internal partial class EmployeeRoleJsonSerializerContext : JsonSerializerContext { }