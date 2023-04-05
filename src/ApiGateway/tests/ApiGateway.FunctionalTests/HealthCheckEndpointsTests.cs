// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.ApiGateway.FunctionalTests;

public class HealthCheckEndpointsTests : EndpointsTestBase
{
    public HealthCheckEndpointsTests(TestWebApplicationFactory<Program> factory)
        : base(factory)
    {
    }

    [Fact]
    public async Task HealthCheckEndpoints_ReturnsOk()
    {
        // Act
        var response = await Client.GetAsync("/hc");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task LiveCheckEndpoints_ReturnsOk()
    {
        // Act
        var response = await Client.GetAsync("/liveness");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
