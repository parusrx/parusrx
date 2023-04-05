// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using ParusRx.EventBus.Events;
using Microsoft.AspNetCore.Http;

namespace ParusRx.MultiTenancy;

/// <summary>
/// Multi-tenancy middleware.
/// </summary>
/// <remarks>
/// This middleware is used to set tenant for current thread.
/// </remarks>
public class MultiTenancyMiddleware : IMiddleware
{
    private readonly ITenantService _tenantService;
    private readonly IOptions<MultiTenancyOptions> _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="MultiTenancyMiddleware"/> class.
    /// </summary>
    /// <param name="tenantService">Tenant service.</param>
    /// <param name="options">Multi-tenancy options.</param>
    public MultiTenancyMiddleware(ITenantService tenantService, IOptions<MultiTenancyOptions> options)
    {
        _tenantService = tenantService;
        _options = options;
    }

    /// <inheritdoc/>
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // Enable buffering so the request body can be read multiple times
        context.Request.EnableBuffering();

        if (context.Request.Method == "POST" && context.Request.Body.CanRead)
        {
            var @event = await context.Request.ReadFromJsonAsync<IntegrationEvent>();
            var tenant = _options.Value?.Tenants?.FirstOrDefault(t => t.Name == @event?.TenantId);

            // If tenant not found throw exception
            if (tenant is null)
            {
                throw new Exception($"Tenant {@event?.TenantId} not found.");
            }

            // Set tenant for current thread
            _tenantService.SetTenant(tenant);
        }

        // Reset the request body stream position so the next middleware can read it
        context.Request.Body.Position = 0;

        // Call the next delegate/middleware in the pipeline
        await next(context);
    }
}