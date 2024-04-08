// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Infrastructure.Services;

/// <summary>
/// Default implementation of <see cref="IMgdIntegrationService"/>.
/// </summary>
public class MgdIntegrationService : IMgdIntegrationService
{
    private readonly IIdentityService _identityService;
    private readonly IMgdService _mgdService;
    private readonly IMessageHandler _messageHandler;
    private readonly ICipherService _cipherService;
    private readonly ILogger<MgdIntegrationService> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="MgdIntegrationService"/> class.
    /// </summary>
    /// <param name="identityService">The <see cref="IIdentityService"/>.</param>
    /// <param name="mgdService">The <see cref="IMgdService"/>.</param>
    /// <param name="messageHandler">The <see cref="IMessageHandler"/>.</param>
    /// <param name="cipherService">The <see cref="ICipherService"/>.</param>
    /// <param name="logger">The logger to use.</param>
    public MgdIntegrationService(IIdentityService identityService,
        IMgdService mgdService,
        IMessageHandler messageHandler,
        ICipherService cipherService,
        ILogger<MgdIntegrationService> logger)
    {
        _identityService = identityService;
        _mgdService = mgdService;
        _messageHandler = messageHandler;
        _cipherService = cipherService;
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task<MgdIntegrationResult> GetMessageAsync(Credential credentials)
    {
        try
        {
            var token = await _identityService.GetTokenAsync(credentials.Username, credentials.Password);

            var message = await _mgdService.GetMessageAsync(token.AccessToken);
            if (message == null)
            {
                _logger.LogInformation("No messages.");
                return MgdIntegrationResult.Failed("There are no available documents.");
            }

            _logger.LogDebug("Message: {message}", message.ToString());

            await _messageHandler.HandleAsync(long.Parse(credentials.CompanyId), long.Parse(credentials.JuridicalPersonId), message);

            var verifyResult = await _cipherService.VerifyXmlAsync(new VerifyData
            {
                ContentAsBase64 = message.Data,
                SignatureAsBase64 = message.Sign
            });

            var signature = await _cipherService.SignXmlAsync(new SignData { ContentAsBase64 = message.Data });

            var ticket = new Ticket
            {
                TaxCode = message.Taxcode,
                Code = message.Code,
                Kpp = message.Kpp,
                DocumentId = message.DocumentId,
                Class = message.Class,
                Status = message.Status,
                RecordTimeStamp = message.RecordTimeStamp,
                ResultValidationSign = verifyResult,
                Sign = signature
            };

            var response = await _mgdService.SendTicketAsync(ticket, token.AccessToken);
            if (response != null)
            {
                _logger.LogInformation("Response: {responsse}", response.Response);
            }

            _logger.LogInformation("Document received [{message}].", message);

            return MgdIntegrationResult.Success;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError("Authentication failed [username: \"{username}\"; password: \"{password}\"].", credentials.Username, credentials.Password);
            return MgdIntegrationResult.Failed("Authentication failed");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to received document.");
            return MgdIntegrationResult.Failed("Failed to received document.");
        }
    }
}
