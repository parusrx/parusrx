// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Handlers;

/// <summary>
/// Handles integration events of type <see cref="MqIntegrationEvent"/> related to application type requests.
/// </summary>
/// <remarks>
/// This handler processes integration events by retrieving the request data from the store,
/// deserializing it, invoking the application type service to fetch the response, and saving the response back to the
/// store. If an error occurs during processing, the error is logged and recorded in the store.
/// </remarks>
/// <param name="store">The Parus RX store.</param>
/// <param name="service">The application type service.</param>
/// <param name="logger">The logger.</param>
public sealed class ApplicationTypeRequestIntegrationEventHandler(IParusRxStore store, IApplicationTypeService service, ILogger<ApplicationTypeRequestIntegrationEventHandler> logger)
    : IIntegrationEventHandler<MqIntegrationEvent>
{
    /// <inheritdoc />
    public async Task HandleAsync(MqIntegrationEvent @event, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Handling integration event: {IntegrationEventId} - {IntegrationEvent}", @event.Id, @event);
        string id = @event.Body;
        try
        {
            byte[] data = await store.ReadDataRequestAsync(id);
            var request = XmlSerializerUtility.Deserialize<ApplicationTypeRequest>(data);

            if (request is not null)
            {
                var response = await service.GetApplicationTypesAsync(request, cancellationToken);
                if (response is not null)
                {
                    byte[]? responseData = XmlSerializerUtility.Serialize(response);
                    if (responseData is not null)
                    {
                        await store.SaveDataResponseAsync(id, responseData);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            await store.ErrorAsync(id, ex.Message);
            logger.LogError(ex, "Error handling integration event: {IntegrationEventId} - {IntegrationEvent}", @event.Id, @event);
        }
    }
}

/// <summary>
/// Represents the application type request.
/// </summary>
[XmlRoot("applicationTypeRequest")]
public record ApplicationTypeRequest
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
/// Represents an application type response.
/// </summary>
[XmlRoot("applicationTypeResponse")]
public record ApplicationTypeResponse
{
    /// <summary>
    /// The result of the files upload.
    /// </summary>
    [XmlElement("result")]
    [JsonPropertyName("result")]
    public required bool Result { get; init; }

    /// <summary>
    /// The list of application types.
    /// </summary>
    [XmlArray("applicationTypes")]
    [XmlArrayItem("applicationTypesItem")]
    [JsonPropertyName("applicationTypes")]
    public required ApplicationType[] ApplicationTypes { get; init; } = [];
}