// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using ParusRx.EventBus.Abstractions;
using ParusRx.Storage;
using ParusRx.Xml;

namespace ParusRx.HRLink.EmployeeRole.API;

/// <summary>
/// The employee role integration event handler.
/// </summary>
internal sealed class EmployeeRoleIntegrationEventHandler : IIntegrationEventHandler<MqIntegrationEvent>
{
    private readonly IParusRxStore _store;
    private readonly IEmployeeRoleClient _client;
    private readonly ILogger<EmployeeRoleIntegrationEventHandler> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmployeeRoleIntegrationEventHandler"/> class.
    /// </summary>
    /// <param name="store">The <see cref="IParusRxStore"/>.</param>
    /// <param name="client">The <see cref="IEmployeeRoleClient"/>.</param>
    /// <param name="logger">The logger to use.</param>
    public EmployeeRoleIntegrationEventHandler(IParusRxStore store,
        IEmployeeRoleClient client,
        ILogger<EmployeeRoleIntegrationEventHandler> logger)
    {
        _store = store;
        _client = client;
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task HandleAsync(MqIntegrationEvent @event, CancellationToken cancellationToken = default)
    {
        using var scope = _logger.BeginScope("Handling integration event {IntegrationEventId} of type {IntegrationEventType}",
            @event.Id, @event.GetType().Name);

        _logger.LogInformation("Handling integration event: {IntegrationEventId} - ({@IntegrationEvent})", @event.Id, @event);

        string id = @event.Body;

        try
        {
            byte[] data = await _store.ReadDataRequestAsync(id);

            var employeeRolesRequest = XmlSerializerUtility.Deserialize<EmployeeRolesRequest>(data);
            if (employeeRolesRequest is not null)
            {
                var employeeRolesResponse = await _client.GetEmployeeRolesAsync(employeeRolesRequest.Url, employeeRolesRequest.ApiToken, cancellationToken);
                var employeeRoleItems = employeeRolesResponse?.EmployeeRoles?.AsEmployeeRolesDto();
                if (employeeRoleItems is not null)
                {
                    byte[]? response = XmlSerializerUtility.Serialize(employeeRoleItems);
                    if (response is not null)
                    {
                        await _store.SaveDataResponseAsync(id, response);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            await _store.ErrorAsync(id, ex.Message);
            _logger.LogError(ex, "Error while processing integration event {IntegrationEventId} of type {IntegrationEventType}: {message}", @event.Id, @event.GetType().Name, ex.Message);
        }
    }
}
