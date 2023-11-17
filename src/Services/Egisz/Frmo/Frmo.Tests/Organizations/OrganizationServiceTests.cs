// // Copyright (c) The Parus RX Authors. All rights reserved.
// // Licensed under the MIT License. See LICENSE in the project root for license information.

// namespace ParusRx.Frmo.Tests;

// public class OrganizationServiceTests
// {
//     private readonly Mock<IOptionsSnapshot<FrmoSettings>> _settingsMock;
//     private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
//     private readonly OrganizationService _organizationService;

//     public OrganizationServiceTests()
//     {
//         _settingsMock = new Mock<IOptionsSnapshot<FrmoSettings>>();
//         _settingsMock.Setup(s => s.Value).Returns(new FrmoSettings { Url = "https://ips.test.egisz.rosminzdrav.ru/4f52d90e921a0" });

//         _httpMessageHandlerMock = new Mock<HttpMessageHandler>();

//         _organizationService = new OrganizationService(new HttpClient(_httpMessageHandlerMock.Object), _settingsMock.Object);
//     }

//     [Fact]
//     public async Task GetByOidAsync_ReturnsOrganization()
//     {
//         // Arrange
//         string oid = "1.2.643.5.1.13.13.12.2.78.6258";
//         GetByOidOrganizationResponse expectedResponse = new()
//         {
//             RequestId = Guid.NewGuid().ToString(),
//             Message = null,
//             Content = new Organization
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
//         var response = await _organizationService.GetByOidAsync(oid);

//         // Assert
//         Assert.NotNull(response);
//         Assert.NotNull(response.Content);
//         Assert.Equal(expectedResponse.Content.Oid, response.Content.Oid);

//         _httpMessageHandlerMock.Protected().Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
//     }

//     [Fact]
//     public async Task ListPagedAsync_ReturnsOrganizations()
//     {
//         // Arrange
//         int orgTypeId = 1;
//         int offset = 0;
//         int limit = 2;

//         var expectedResponse = new ListPagedOrganizationResponse
//         {
//             RequestId = Guid.NewGuid().ToString(),
//             Message = null,
//             Offset = offset,
//             Limit = limit,
//             Total = 2,
//             Content = new List<Organization>
//             {
//                 new() { Oid = "1.2.643.5.1.13.13.12.2.78.6258" },
//                 new() { Oid = "1.2.643.5.1.13.13.12.2.78.9235" }
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
//         var response = await _organizationService.ListPagedAsync(orgTypeId, offset, limit);

//         // Assert
//         Assert.NotNull(response);
//         Assert.NotNull(response.Content);
//         Assert.Equal(expectedResponse.Content.Count, response.Content.Count);

//         _httpMessageHandlerMock.Protected().Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
//     }

//     [Fact]
//     public async Task UpdateAsync_ReturnsSuccess()
//     {
//         // Arrange
//         string oid = "1.2.643.5.1.13.13.12.2.78.6258";
//         Organization organization = new()
//         {
//             Oid = oid,
//             NameFull = "Test"
//         };
//         UpdateOrganizationResponse expectedResponse = new()
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
//         var response = await _organizationService.UpdateAsync(oid, organization);

//         // Assert
//         Assert.NotNull(response);
//         Assert.Equal(expectedResponse.RequestId, response.RequestId);

//         _httpMessageHandlerMock.Protected().Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
//     }

//     [Fact]
//     public async Task DeleteAsync_ReturnsSuccess()
//     {
//         // Arrange
//         string oid = "1.2.643.5.1.13.13.12.2.78.6258";
//         int deleteReason = 1;
//         DeleteOrganizationResponse expectedResponse = new()
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
//         var response = await _organizationService.DeleteAsync(oid, deleteReason);

//         // Assert
//         Assert.NotNull(response);
//         Assert.Equal(expectedResponse.RequestId, response.RequestId);

//         _httpMessageHandlerMock.Protected().Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
//     }
// }
