// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.FunctionalTests;

public class LivenessEndpointTests
{
    [Fact]
    public async void GetLiveness_ReturnsHealthy()
    {
        // Arrange
        using var app = new HRlinkApplication();
        var client = app.CreateClient();

        // Act
        var response = await client.GetAsync("/liveness");

        // Assert
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.Equal("Healthy", content);
    }
}