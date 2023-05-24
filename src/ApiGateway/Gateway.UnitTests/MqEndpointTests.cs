// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using ParusRx.EventBus.Abstractions;
using ParusRx.EventBus.Events;

namespace ParusRx.Gateway.API.UnitTests;

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
        var result = (Created)await MqEndpoint.PublishMessage(message, mock.Object);

        // Assert
        Assert.Equal(StatusCodes.Status201Created, result.StatusCode);
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
        var result = (BadRequest)await MqEndpoint.PublishMessage(null, mock.Object);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        // Assert
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }
}