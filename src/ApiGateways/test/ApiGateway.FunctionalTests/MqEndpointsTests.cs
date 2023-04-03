// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRX.ApiGateway.FunctionalTests;

public class MqEndpointsV1Tests : EndpointsTestBase
{
    public MqEndpointsV1Tests(TestWebApplicationFactory<Program> factory)
        : base(factory)
    {
    }

    public static IEnumerable<object[]> BadMessages => new List<object[]>
    {
        new object[] { new Message(Topic: "test", Payload: null)},
        new object[] { new Message(Topic: null, Payload: "test")}
    };

    [Fact]
    public async Task PublishMessage_PostMethod_ShouldBeReturnOk()
    {
        // Arrange
        var message = new Message(Topic: "test", Payload: "test");
        
        Client.DefaultRequestHeaders.Add("X-Tenant-Id", "tenant");

        // Act
        var response = await Client.PostAsJsonAsync("api/v1/mq", message);

        // Assert
        Assert.Equal(StatusCodes.Status200OK, (int)response.StatusCode);
    }

    [Fact]
    public async Task PublishMessage_IfTenantIdIsNull_ShouldBeReturnBadRequest()
    {
        // Arrange
        var message = new Message(Topic: "test", Payload: "test");

        // Act
        var response = await Client.PostAsJsonAsync("api/v1/mq", message);

        // Assert
        Assert.Equal(StatusCodes.Status400BadRequest, (int)response.StatusCode);
    }

    [Fact]
    public async Task PublishMessage_IfMessageIsNull_ShouldBeReturnBadRequest()
    {
        // Arrange
        Client.DefaultRequestHeaders.Add("X-Tenant-Id", "tenant");

        // Act
        #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        var response = await Client.PostAsJsonAsync("api/v1/mq", (Message)null);
        #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        // Assert
        Assert.Equal(StatusCodes.Status400BadRequest, (int)response.StatusCode);
    }

    [Theory]
    [MemberData(nameof(BadMessages))]
    public async Task PublishMessage_IfMessageIsInvalid_ShouldBeReturnBadRequest(Message message)
    {
        // Arrange
        Client.DefaultRequestHeaders.Add("X-Tenant-Id", "tenant");

        // Act
        var response = await Client.PostAsJsonAsync("api/v1/mq", message);

        // Assert
        Assert.Equal(StatusCodes.Status400BadRequest, (int)response.StatusCode);
    }
}