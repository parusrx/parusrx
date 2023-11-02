// // Copyright (c) The Parus RX Authors. All rights reserved.
// // Licensed under the MIT License. See LICENSE in the project root for license information.

// using ParusRx.Frmo.API.Services;

// namespace ParusRx.Frmo.Tests;

// public class ListPagedDepartmentIntegrationEventHandlerTests
// {
//     private readonly Mock<IParusRxStore> _storeMock;
//     private readonly Mock<IDepartmentService> _serviceMock;
//     private readonly Mock<ILogger<ListPagedDepartmentIntegrationEventHandler>> _loggerMock;

//     public ListPagedDepartmentIntegrationEventHandlerTests()
//     {
//         _storeMock = new Mock<IParusRxStore>();
//         _serviceMock = new Mock<IDepartmentService>();
//         _loggerMock = new Mock<ILogger<ListPagedDepartmentIntegrationEventHandler>>();
//     }

//     [Fact]
//     public async Task HandleAsync_WithValidRequest_SaveDataResponse()
//     {
//         // Arrange
//         MqIntegrationEvent @event = new(Guid.NewGuid().ToString());

//         ListPagedDepartmentRequest request = new()
//         {
//             Parameters = new()
//             {
//                 DepartTypeId = 1,
//                 Oid = "1.2.643.5.1.13.13.12.2.77.7799"
//             }
//         };

//         ListPagedDepartmentResponse response = new()
//         {
//             RequestId = Guid.NewGuid().ToString(),
//             Message = null,
//             Offset = request.Parameters.Offset,
//             Limit = request.Parameters.Limit,
//             Total = 2,
//             Content = new()
//             {
//                 new Department { Oid = "1.2.643.5.1.13.13.12.2.77.7799", DepartName = "Department 1" },
//                 new Department { Oid = "1.2.643.5.1.13.13.12.2.78.7799", DepartName = "Department 2" },
//             }
//         };

//         _storeMock.Setup(s => s.ReadDataRequestAsync(@event.Body)).ReturnsAsync(XmlSerializerUtility.Serialize(request)!);
//         _storeMock.Setup(s => s.SaveDataResponseAsync(@event.Body, It.IsAny<byte[]>())).Returns(Task.CompletedTask);
//         _serviceMock.Setup(s => s.ListPagedAsync(request.Parameters.DepartTypeId, request.Parameters.Oid, request.Parameters.Offset, request.Parameters.Limit, It.IsAny<CancellationToken>())).ReturnsAsync(response);

//         var handler = new ListPagedDepartmentIntegrationEventHandler(_storeMock.Object, _serviceMock.Object, _loggerMock.Object);

//         // Act
//         await handler.HandleAsync(@event);

//         // Assert
//         _storeMock.Verify(s => s.ReadDataRequestAsync(@event.Body), Times.Once());
//         _storeMock.Verify(s => s.SaveDataResponseAsync(@event.Body, It.IsAny<byte[]>()), Times.Once());
//         _serviceMock.Verify(s => s.ListPagedAsync(request.Parameters.DepartTypeId, request.Parameters.Oid, request.Parameters.Offset, request.Parameters.Limit, It.IsAny<CancellationToken>()), Times.Once());
//     }
// }
