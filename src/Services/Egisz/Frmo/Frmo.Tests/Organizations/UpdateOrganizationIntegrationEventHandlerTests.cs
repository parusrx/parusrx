// // Copyright (c) Alexander Bocharov.
// // Licensed under the MIT License. See the LICENSE file in the project root for more information.

// namespace ParusRx.Frmo.Tests;

// public class UpdateOrganizationIntegrationEventHandlerTests
// {
//     private readonly Mock<IParusRxStore> _storeMock;
//     private readonly Mock<IOrganizationService> _serviceMock;
//     private readonly Mock<ILogger<UpdateOrganizationIntegrationEventHandler>> _loggerMock;

//     public UpdateOrganizationIntegrationEventHandlerTests()
//     {
//         _storeMock = new Mock<IParusRxStore>();
//         _serviceMock = new Mock<IOrganizationService>();
//         _loggerMock = new Mock<ILogger<UpdateOrganizationIntegrationEventHandler>>();
//     }

//     [Fact]
//     public async Task HandleAsync_WithValidRequest_SaveDataResponse()
//     {
//         // Arrange
//         MqIntegrationEvent @event = new(Guid.NewGuid().ToString());

//         UpdateOrganizationRequest request = new()
//         {
//             Parameters = new()
//             {
//                 Oid = "1.2.643.5.1.13.13.12.2.78.6258"
//             },
//             Content = new()
//             {
//                 Organization = new()
//                 {
//                     Oid = "1.2.643.5.1.13.13.12.2.78.6258"
//                 }
//             }
//         };

//         UpdateOrganizationResponse response = new()
//         {
//             RequestId = Guid.NewGuid().ToString(),
//             Message = null
//         };

//         _storeMock.Setup(s => s.ReadDataRequestAsync(@event.Body)).ReturnsAsync(XmlSerializerUtility.Serialize(request)!);
//         _storeMock.Setup(s => s.SaveDataResponseAsync(@event.Body, It.IsAny<byte[]>())).Returns(Task.CompletedTask);
//         _serviceMock.Setup(s => s.UpdateAsync(It.IsAny<string>(), It.IsAny<Organization>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);

//         var handler = new UpdateOrganizationIntegrationEventHandler(_storeMock.Object, _serviceMock.Object, _loggerMock.Object);

//         // Act
//         await handler.HandleAsync(@event);

//         // Assert
//         _storeMock.Verify(s => s.ReadDataRequestAsync(@event.Body), Times.Once());
//         _storeMock.Verify(s => s.SaveDataResponseAsync(@event.Body, It.IsAny<byte[]>()), Times.Once());
//         _serviceMock.Verify(s => s.UpdateAsync(It.IsAny<string>(), It.IsAny<Organization>(), It.IsAny<CancellationToken>()), Times.Once());
//     }

//     [Fact]
//     public async Task HandleAsync_WithException_SaveErrorAndLogError()
//     {
//         // Arrange
//         MqIntegrationEvent @event = new(Guid.NewGuid().ToString());

//         _storeMock.Setup(s => s.ReadDataRequestAsync(@event.Body)).ThrowsAsync(new InvalidOperationException());

//         var handler = new UpdateOrganizationIntegrationEventHandler(_storeMock.Object, _serviceMock.Object, _loggerMock.Object);

//         // Act
//         await handler.HandleAsync(@event);

//         // Assert
//         _storeMock.Verify(s => s.ReadDataRequestAsync(@event.Body), Times.Once());
//         _storeMock.Verify(s => s.ErrorAsync(@event.Body, It.IsAny<string>()), Times.Once());
//         _loggerMock.Verify(
//             x => x.Log(
//                 LogLevel.Error,
//                 It.IsAny<EventId>(),
//                 It.Is<It.IsAnyType>((o, t) => o.ToString()!.Contains($"Error handling integration event: {@event.Id} - {@event}")),
//                 It.IsAny<Exception>(),
//                 (Func<It.IsAnyType, Exception?, string>)It.IsAny<object>()), 
//             Times.Once);
//     }
// }
