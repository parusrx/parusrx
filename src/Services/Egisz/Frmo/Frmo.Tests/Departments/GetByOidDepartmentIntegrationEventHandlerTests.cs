// // Copyright (c) The Parus RX Authors. All rights reserved.
// // Licensed under the MIT License. See LICENSE in the project root for license information.

// using ParusRx.Frmo.API.Services;

// namespace ParusRx.Frmo.Tests;

// public class GetByOidDepartmentIntegrationEventHandlerTests
// {
//     private readonly Mock<IParusRxStore> _storeMock;
//     private readonly Mock<IDepartmentService> _serviceMock;
//     private readonly Mock<ILogger<GetByOidDepartmentIntegrationEventHandler>> _loggerMock;

//     public GetByOidDepartmentIntegrationEventHandlerTests()
//     {
//         _storeMock = new Mock<IParusRxStore>();
//         _serviceMock = new Mock<IDepartmentService>();
//         _loggerMock = new Mock<ILogger<GetByOidDepartmentIntegrationEventHandler>>();
//     }

//     [Fact]
//     public async Task HandleAsync_WithValidRequest_SaveDataResponse()
//     {
//         // Arrange
//         MqIntegrationEvent @event = new(Guid.NewGuid().ToString());

//         GetByOidDepartmentRequest request = new()
//         {
//             Parameters = new()
//             {
//                 DepartOid = "1.2.643.5.1.13.13.12.2.77.7799",
//                 Oid = "1.2.643.5.1.13.13.12.2.77.7799"
//             }
//         };

//         GetByOidDepartmentResponse response = new()
//         {
//             RequestId = Guid.NewGuid().ToString(),
//             Message = null,
//             Content = new Department
//             {
//                 Oid = request.Parameters.DepartOid
//             }
//         };

//         _storeMock.Setup(s => s.ReadDataRequestAsync(@event.Body)).ReturnsAsync(XmlSerializerUtility.Serialize(request)!);
//         _storeMock.Setup(s => s.SaveDataResponseAsync(@event.Body, It.IsAny<byte[]>())).Returns(Task.CompletedTask);
//         _serviceMock.Setup(s => s.GetAsync(request.Parameters.DepartOid, request.Parameters.Oid, It.IsAny<CancellationToken>())).ReturnsAsync(response);

//         var handler = new GetByOidDepartmentIntegrationEventHandler(_storeMock.Object, _serviceMock.Object, _loggerMock.Object);

//         // Act
//         await handler.HandleAsync(@event);

//         // Assert
//         _storeMock.Verify(s => s.ReadDataRequestAsync(@event.Body), Times.Once());
//         _storeMock.Verify(s => s.SaveDataResponseAsync(@event.Body, It.IsAny<byte[]>()), Times.Once());
//         _serviceMock.Verify(s => s.GetAsync(request.Parameters.DepartOid, request.Parameters.Oid, It.IsAny<CancellationToken>()), Times.Once());
//     }

//     [Fact]
//     public async Task HandleAsync_WithInvalidRequest_ThrowsInvalidOperationException()
//     {
//         // Arrange
//         MqIntegrationEvent @event = new(Guid.NewGuid().ToString());

//         _storeMock.Setup(s => s.ReadDataRequestAsync(@event.Body)).ThrowsAsync(new InvalidOperationException());

//         var handler = new GetByOidDepartmentIntegrationEventHandler(_storeMock.Object, _serviceMock.Object, _loggerMock.Object);

//         // Act
//         await handler.HandleAsync(@event);

//         // Assert
//         _storeMock.Verify(x => x.ErrorAsync(@event.Body, It.IsAny<string>()), Times.Once());
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
