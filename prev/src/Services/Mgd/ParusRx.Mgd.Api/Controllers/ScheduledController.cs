// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Controllers;

/// <summary>
/// Represents the Scheduled controller.
/// </summary>
public class ScheduledController : Controller
{
    private readonly IMgdIntegrationService _mgdIntegrationService;
    private readonly ICredentialsStore _credentialsStore;

    /// <summary>
    /// Initializes a new instance of <see cref="ScheduledController"/>.
    /// </summary>
    /// <param name="mgdIntegrationService">The <see cref="IMgdIntegrationService"/>.</param>
    /// <param name="credentialsStore">The <see cref="ICredentialsStore"/>.</param>
    public ScheduledController(IMgdIntegrationService mgdIntegrationService,
        ICredentialsStore credentialsStore)
    {
        _mgdIntegrationService = mgdIntegrationService;
        _credentialsStore = credentialsStore;
    }

    /// <summary>
    /// Retrieves a message.
    /// </summary>
    /// <remarks>
    ///     POST /scheduled
    /// </remarks>
    /// <responce code="200">Successful completion.</responce>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [Route("scheduled")]
    public async Task<IActionResult> ReceiveMessagesAsync()
    {
        foreach (var credentials in await _credentialsStore.GetAllCredentialsAsync())
        {
            await _mgdIntegrationService.GetMessageAsync(credentials);
        }

        return Ok();
    }
}
