// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.WebProxy.Controllers;

/// <summary>
/// This controller implements the message queue logic.
/// </summary>
[Route("api/v1/[controller]")]
[ApiController]
public class MqController : ControllerBase
{
    private readonly IEventBus _eventBus;
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of <see cref="MqController"/>.
    /// </summary>
    /// <param name="eventBus">The <see cref="IEventBus"/>.</param>
    /// <param name="logger">The logger to use.</param>
    public MqController(IEventBus eventBus, ILogger<MqController> logger)
    {
        _eventBus = eventBus;
        _logger = logger;
    }

    /// <summary>
    /// Send message to queue.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <response code="202">Returns on successful submission.</response>
    /// <response code="400">If the message is null.</response>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Accepted)]
    public async Task<IActionResult> PostAsync([FromBody] MessageQueue message)
    {
        if (message == null)
        {
            return BadRequest();
        }

        var @event = new IntegrationEvent { Metadata = message.Message };

        try
        {
            await _eventBus.PublishAsync(message.Topic, @event);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ERROR Publishing integration event: {IntegrationEventId} from {AppName}", @event.Id, Program.AppName);

            throw;
        }

        return Accepted();
    }
}
