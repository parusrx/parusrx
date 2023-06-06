// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Net;

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace ParusRx.HRLink.DocumentType.FunctionalTests;

public class DocumentTypeTests
{
    [Fact]
    public async void HealthCheck_ReturnsOk()
    {
        // Arrange
        await using var application = new DocumentTypeApplication();

        // Act
        var client = application.CreateClient();
        var response = await client.GetAsync("/health");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void LiveCheck_ReturnsOk()
    {
        // Arrange
        await using var application = new DocumentTypeApplication();

        // Act
        var client = application.CreateClient();
        var response = await client.GetAsync("/liveness");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    class DocumentTypeApplication : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            return base.CreateHost(builder);
        }
    }
}