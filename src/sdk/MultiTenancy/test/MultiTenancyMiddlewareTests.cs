// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace ParusRX.MultiTenancy.Tests;

public class MultiTenancyMiddlewareTests
{
    [Fact]
    public async Task MultiTenancyMiddleware_ShouldThrowExceptionIfTenantNotFound()
    {
        // Arrange
        var tenantService = new TenantService();
        var options = new MultiTenancyOptions
        {
            Tenants = new List<ITenant>
            {
                new StubTenant
                {
                    Name = "Test"
                }
            }
        };
        var middleware = new MultiTenancyMiddleware(tenantService, Options.Create(options));
        var context = new DefaultHttpContext();
        context.Request.Method = "POST";
        context.Request.ContentType = "application/json";
        context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes("{\"TenantId\":\"Test1\"}"));

        // Act
        var exception = await Assert.ThrowsAsync<Exception>(() => middleware.InvokeAsync(context, _ => Task.CompletedTask));

        // Assert
        Assert.Equal("Tenant Test1 not found.", exception.Message);
    }

    [Fact]
    public async Task MultiTenancyMiddleware_ShouldSetTenant()
    {
        // Arrange
        var tenantService = new TenantService();
        var options = new MultiTenancyOptions
        {
            Tenants = new List<ITenant>
            {
                new StubTenant
                {
                    Name = "Test"
                }
            }
        };
        var middleware = new MultiTenancyMiddleware(tenantService, Options.Create(options));
        var context = new DefaultHttpContext();
        context.Request.Method = "POST";
        context.Request.ContentType = "application/json";
        context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes("{\"TenantId\":\"Test\"}"));

        // Act
        await middleware.InvokeAsync(context, _ => Task.CompletedTask);

        // Assert
        Assert.Equal("Test", tenantService.Tenant?.Name);
    }
}