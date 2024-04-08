// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Gateway.FunctionalTests;

public class HealthCheckEndpointsTest : TestBase
{
    public HealthCheckEndpointsTest(TestWebApplicationFactory<Program> factory)
        : base(factory)
    {
    }

    [Fact]
    public async Task HealthCheckEndpoints_ReturnsOk()
    {
        // Act
        var response = await Client.GetAsync("/health");

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