// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Handlers;

/// <summary>
/// The document type request integration event handler.
/// </summary>
/// <param name="store">The ParusRx store.</param>
/// <param name="httpClientFactory">The HTTP client factory.</param>
/// <param name="logger">The logger.</param>
public sealed class DocumentTypeRequestIntegrationEventHandler(IParusRxStore store, IHttpClientFactory httpClientFactory, ILogger<DocumentTypeRequestIntegrationEventHandler> logger)
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
            var DocumentTypesRequest = XmlSerializerUtility.Deserialize<DocumentTypesRequest>(data);
            if (DocumentTypesRequest is not null)
            {
                var httpClient = httpClientFactory.CreateClient();
                httpClient.BaseAddress = new Uri(DocumentTypesRequest.Url);
                httpClient.DefaultRequestHeaders.Add("User-Api-Token", DocumentTypesRequest.ApiToken);

                var documentTypes = await httpClient.GetFromJsonAsync("api/v1/documentTypes", DocumentTypeJsonSerializerContext.Default.DocumentTypesResponse, cancellationToken: cancellationToken);
                if (documentTypes is not null)
                {
                    byte[]? response = XmlSerializerUtility.Serialize(documentTypes);
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
/// Represents a request of document types.
/// </summary>
[XmlRoot("documentTypesRequest")]
public record DocumentTypesRequest
{
    /// <summary>
    /// Gets or sets the URL.
    /// </summary>
    [XmlElement("url")]
    [JsonPropertyName("url")]
    public required string Url { get; init; }

    /// <summary>
    /// Gets or sets the API token.
    /// </summary>
    [XmlElement("apiToken")]
    [JsonPropertyName("apiToken")]
    public required string ApiToken { get; init; }
}

/// <summary>
/// Represents a response of document types.
/// </summary>
[XmlRoot("documentTypesResponse")]
public record DocumentTypesResponse
{
    /// <summary>
    /// Gets or sets the result.
    /// </summary>
    [XmlElement("result")]
    [JsonPropertyName("result")]
    public required bool Result { get; init; }
    /// <summary>
    /// Gets or sets the document types.
    /// </summary>
    [XmlArray("documentTypes")]
    [XmlArrayItem("documentType")]
    [JsonPropertyName("documentTypes")]
    public DocumentType[]? DocumentTypes { get; init; }
}

[JsonSourceGenerationOptions(
    GenerationMode = JsonSourceGenerationMode.Metadata,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(MqIntegrationEvent))]
[JsonSerializable(typeof(DocumentType[]))]
[JsonSerializable(typeof(DocumentTypesRequest))]
[JsonSerializable(typeof(DocumentTypesResponse))]
internal partial class DocumentTypeJsonSerializerContext : JsonSerializerContext { }