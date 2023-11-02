// // Copyright (c) The Parus RX Authors. All rights reserved.
// // Licensed under the MIT License. See LICENSE in the project root for license information.

// using ParusRx.Frmo.API.Services;

// namespace ParusRx.Frmo.Tests;

// public class DepartmentServiceTests
// {
//     private readonly Mock<IOptionsSnapshot<FrmoSettings>> _settingsMock;
//     private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
//     private readonly IDepartmentService _departmentService;

//     public DepartmentServiceTests()
//     {
//         _settingsMock = new Mock<IOptionsSnapshot<FrmoSettings>>();
//         _settingsMock.Setup(s => s.Value).Returns(new FrmoSettings { Url = "https://ips.test.egisz.rosminzdrav.ru/4f52d90e921a0" });

//         _httpMessageHandlerMock = new Mock<HttpMessageHandler>();

//         _departmentService = new DepartmentService(new HttpClient(_httpMessageHandlerMock.Object), _settingsMock.Object);
//     }

//     [Fact]
//     public async Task GetByOidAsync_ReturnsDepartment()
//     {
//         // Arrange
//         string departOid = "1.2.643.5.1.13.13.12.2.77.7799";
//         string oid = "1.2.643.5.1.13.13.12.2.77.7799";

//         GetByOidDepartmentResponse expectedResponse = new()
//         {
//             RequestId = Guid.NewGuid().ToString(),
//             Message = null,
//             Content = new Department
//             {
//                 Oid = oid
//             }
//         };

//         _httpMessageHandlerMock.Protected()
//             .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
//             .ReturnsAsync(new HttpResponseMessage
//             {
//                 StatusCode = HttpStatusCode.OK,
//                 Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
//             });

//         // Act
//         var response = await _departmentService.GetAsync(departOid, oid);

//         // Assert
//         Assert.NotNull(response);
//         Assert.NotNull(response.Content);
//         Assert.Equal(expectedResponse.Content.Oid, response.Content.Oid);

//         _httpMessageHandlerMock.Protected().Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
//     }

//     [Fact]
//     public async Task ListPagedAsync_ReturnsDepartments()
//     {
//         // Arrange
//         int departTypeId = 1;
//         string oid = "1.2.643.5.1.13.13.12.2.78.6258";
//         int offset = 0;
//         int limit = 2;

//         ListPagedDepartmentResponse expectedResponse = new()
//         {
//             RequestId = Guid.NewGuid().ToString(),
//             Message = null,
//             Content = new List<Department>
//             {
//                 new() { DepartName = "Department 1" },
//                 new() { DepartName = "Department 2" }
//             }
//         };

//         _httpMessageHandlerMock.Protected()
//             .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
//             .ReturnsAsync(new HttpResponseMessage
//             {
//                 StatusCode = HttpStatusCode.OK,
//                 Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
//             });

//         // Act
//         var response = await _departmentService.ListPagedAsync(departTypeId, oid, offset, limit);

//         // Assert
//         Assert.NotNull(response);
//         Assert.NotNull(response.Content);
//         Assert.Equal(expectedResponse.Content.Count, response.Content.Count);

//         _httpMessageHandlerMock.Protected().Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
//     }

//     [Fact]
//     public async Task CreateAsync_ReturnsDepartmentEntityId()
//     {
//         // Arrange
//         string oid = "1.2.643.5.1.13.13.12.2.77.7799";
        
//         Department department = new()
//         {
//             DepartName = "Department 1"
//         };

//         CreateDepartmentResponse expectedResponse = new()
//         {
//             RequestId = Guid.NewGuid().ToString(),
//             Message = null,
//             Content = new Entity
//             {
//                 EntityId = oid
//             }
//         };

//         _httpMessageHandlerMock.Protected()
//             .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
//             .ReturnsAsync(new HttpResponseMessage
//             {
//                 StatusCode = HttpStatusCode.OK,
//                 Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
//             });

//         // Act
//         var response = await _departmentService.CreateAsync(oid, department);

//         // Assert
//         Assert.NotNull(response);
//         Assert.NotNull(response.Content);
//         Assert.Equal(expectedResponse.Content.EntityId, response.Content.EntityId);

//         _httpMessageHandlerMock.Protected().Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
//     }

//     [Fact]
//     public async Task UpdateAsync_ReturnsSuccess()
//     {
//         // Arrange
//         string oid = "1.2.643.5.1.13.13.12.2.77.7799";

//         Department department = new()
//         {
//             Oid = oid,
//             DepartName = "Department 1"
//         };

//         UpdateDepartmentResponse expectedResponse = new()
//         {
//             RequestId = Guid.NewGuid().ToString(),
//             Message = null
//         };

//         _httpMessageHandlerMock.Protected()
//             .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
//             .ReturnsAsync(new HttpResponseMessage
//             {
//                 StatusCode = HttpStatusCode.OK,
//                 Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
//             });

//         // Act
//         var response = await _departmentService.UpdateAsync(oid, oid, department);

//         // Assert
//         Assert.NotNull(response);
//         Assert.Equal(expectedResponse.RequestId, response.RequestId);

//         _httpMessageHandlerMock.Protected().Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
//     }

//     [Fact]
//     public async Task DeleteAsync_ReturnsSuccess()
//     {
//         // Arrange
//         string oid = "1.2.643.5.1.13.13.12.2.77.7799";

//         DeleteDepartmentResponse expectedResponse = new()
//         {
//             RequestId = Guid.NewGuid().ToString(),
//             Message = null
//         };

//         _httpMessageHandlerMock.Protected()
//             .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
//             .ReturnsAsync(new HttpResponseMessage
//             {
//                 StatusCode = HttpStatusCode.OK,
//                 Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
//             });

//         // Act
//         var response = await _departmentService.DeleteAsync(oid, oid);

//         // Assert
//         Assert.NotNull(response);
//         Assert.Equal(expectedResponse.RequestId, response.RequestId);

//         _httpMessageHandlerMock.Protected().Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
//     }
// }
