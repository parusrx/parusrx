// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EArchive.Api.Integration;

/// <summary>
/// An implementation of <see cref="IEArchiveDocumentEventService"/> for integration events with the BFT e-Archive.
/// </summary>
public class EArchiveDocumentEventService : IEArchiveDocumentEventService
{
    private readonly IParusRxStore _store;
    private readonly IIdentityService _identityService;
    private readonly IEArchiveDocumentService _eArchiveDocumentService;
    private readonly ILogger<EArchiveDocumentEventService> _logger;

    /// <summary>
    /// Initializes a new instanse of <see cref="EArchiveDocumentEventService"/>.
    /// </summary>
    /// <param name="store">The <see cref="IParusRxStore"/>.</param>
    /// <param name="identityService">The <see cref="IIdentityService"/>.</param>
    /// <param name="eArchiveDocumentService">The <see cref="IEArchiveDocumentService"/>.</param>
    /// <param name="logger">The logger to use.</param>
    public EArchiveDocumentEventService(IParusRxStore store,
        IIdentityService identityService,
        IEArchiveDocumentService eArchiveDocumentService,
        ILogger<EArchiveDocumentEventService> logger)
    {
        _store = store;
        _identityService = identityService;
        _eArchiveDocumentService = eArchiveDocumentService;
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task StoreAsync(IntegrationEvent @event)
    {
        var id = @event.Metadata;

        try
        {
            var data = await _store.ReadDataRequestAsync(id);

            var storeDocumentRequest = XmlSerializerUtility.Deserialize<StoreDocumentRequest>(data);
            if (storeDocumentRequest == null)
            {
                throw new ArgumentException("Invalid request.");
            }

            var credential = storeDocumentRequest.Credential;

            var token = await _identityService.GetTokenAsync(credential.Username, credential.Password);
            if (token == null)
            {
                throw new ArgumentException($"Authentication failed[username: \"{credential.Username}\"; password: \"{credential.Password}\"].");
            }

            var document = await _eArchiveDocumentService.StoreAsync(storeDocumentRequest.StoreDocumentBody, token.AccessToken);
            var response = new StoreDocumentResponse
            {
                Document = document
            };

            var responseContent = XmlSerializerUtility.Serialize(response);

            await _store.SaveDataResponseAsync(id, responseContent);
        }
        catch (HttpIntegrationRequestException ex)
        {
            await _store.ErrorAsync(id, ex.Message);

            _logger.LogError(ex, "EXCEPTION ERROR: {message}", ex.Message);
        }
        catch (Exception ex)
        {
            await _store.ErrorAsync(id, ex.Message);

            _logger.LogError(ex, "EXCEPTION ERROR: {message}", ex.Message);
        }
    }

    /// <inheritdoc/>
    public async Task ReadAttachmentAsync(IntegrationEvent @event)
    {
        var id = @event.Metadata;

        try
        {
            var xmlSerializer = new XmlSerializer(typeof(AttachmentRequest));

            var data = await _store.ReadDataRequestAsync(id);

            using var memoryStream = new MemoryStream(data);
            var attachmentRequest = (AttachmentRequest)xmlSerializer.Deserialize(memoryStream);
            if (attachmentRequest == null)
            {
                throw new ArgumentException("The request failed.");
            }

            var credential = attachmentRequest.Credential;

            var token = await _identityService.GetTokenAsync(credential.Username, credential.Password);
            if (token == null)
            {
                throw new ArgumentException($"Authentication failed [username: \"{credential.Username}\"; password: \"{credential.Password}\"].");
            }


            var fileAsBase64 = await _eArchiveDocumentService.ReadAttachmentAsync(attachmentRequest.Attach.Id, token.AccessToken);
            await _store.SaveDataResponseAsync(id, Convert.FromBase64String(fileAsBase64));
        }
        catch (HttpIntegrationRequestException ex)
        {
            await _store.ErrorAsync(id, ex.Message);

            _logger.LogError(ex, "EXCEPTION ERROR: {message}", ex.Message);
        }
        catch (Exception ex)
        {
            await _store.ErrorAsync(id, ex.Message);

            _logger.LogError(ex, "EXCEPTION ERROR: {message}", ex.Message);
        }
    }
}
