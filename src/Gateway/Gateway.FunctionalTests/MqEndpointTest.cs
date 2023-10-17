// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;

namespace ParusRx.Gateway.FunctionalTests;

public class MqEndpointTest : TestBase
{
    public MqEndpointTest(TestWebApplicationFactory<Program> factory)
        : base(factory)
    {
    }

    [Fact]
    public async Task PublishMessage_PostMethod_ShouldBeReturnOk()
    {
        // Arrange
        var message = new MessageQueue(Topic: "test", Message: "test");
        
        // Act
        var response = await Client.PostAsJsonAsync("api/v1/mq", message);

        // Assert
        Assert.Equal(StatusCodes.Status201Created, (int)response.StatusCode);
    }

    [Fact]
    public async Task PublishMessage_IfMessageIsNull_ShouldBeReturnBadRequest()
    {
        // Act
        #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        var response = await Client.PostAsJsonAsync("api/v1/mq", (MessageQueue)null);
        #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        // Assert
        Assert.Equal(StatusCodes.Status400BadRequest, (int)response.StatusCode);
    }
}