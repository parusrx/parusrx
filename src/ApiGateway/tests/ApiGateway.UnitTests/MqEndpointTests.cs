// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using ParusRX.EventBus.Abstractions;
using ParusRX.EventBus.Events;

namespace ParusRX.ApiGateway.UnitTests;

public class MqEndpointTests
{
    [Fact]
    public async Task PublishMessage_ReturnsOk()
    {
        // Arrange
        var mock = new Mock<IEventBus>();
        mock.Setup(x => x.PublishAsync(It.IsAny<string>(), It.IsAny<IntegrationEvent>(), CancellationToken.None))
            .Returns(Task.CompletedTask);

        var message = new Message("test", "test");

        // Act
        var okResult = (Ok)await MqEndpoint.PublishMessage("tenant", message, mock.Object);

        // Assert
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
    }

    [Fact]
    public async Task PublishMessage_IfTenantIdIsNull_ReturnsBadRequest()
    {
        // Arrange
        var mock = new Mock<IEventBus>();
        mock.Setup(x => x.PublishAsync(It.IsAny<string>(), It.IsAny<IntegrationEvent>(), CancellationToken.None))
            .Returns(Task.CompletedTask);

        var message = new Message("test", "test");

        // Act
        #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        var okResult = (BadRequest)await MqEndpoint.PublishMessage(null, message, mock.Object);
        #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        
        // Assert
        Assert.Equal(StatusCodes.Status400BadRequest, okResult.StatusCode);
    }

    [Fact]
    public async Task PublishMessage_IfMessageIsNull_ReturnsBadRequest()
    {
        // Arrange
        var mock = new Mock<IEventBus>();
        mock.Setup(x => x.PublishAsync(It.IsAny<string>(), It.IsAny<IntegrationEvent>(), CancellationToken.None))
            .Returns(Task.CompletedTask);

        // Act
        #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        var okResult = (BadRequest)await MqEndpoint.PublishMessage("tenant", null, mock.Object);
        #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        
        // Assert
        Assert.Equal(StatusCodes.Status400BadRequest, okResult.StatusCode);
    }
}