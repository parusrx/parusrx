// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.FunctionalTests;

public class HealthEndpointTests
{
    [Fact]
    public async void GetHealthChecks_ReturnsHealthy()
    {
        // Arrange
        using var app = new HRlinkApplication();
        var client = app.CreateClient();

        // Act
        var response = await client.GetAsync("/health");

        // Assert
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.Equal("Healthy", content);
    }
}
