//// Copyright (c) Alexander Bocharov.
//// Licensed under the MIT License. See the LICENSE file in the project root for more information.

//namespace ParusRx.HRlink.API.Tests.Services
//{
//    public class RouteTemplateServiceTests
//    {
//        [Fact]
//        public async Task GetRouteTemplatesAsync_WithValidRequest_ReturnsRouteTemplateResponse()
//        {
//            // Arrange
//            var httpClient = new HttpClient();
//            var service = new RouteTemplateService(httpClient);
//            var request = new RouteTemplateRequest
//            {
//                Authorization = new AuthorizationContext
//                {
//                    Url = "https://example.com",
//                    ClientId = "123456",
//                    ApiToken = "abc123"
//                },
//                SigningObjectType = SigningObjectType.DOCUMENT
//            };
//            var cancellationToken = CancellationToken.None;

//            // Act
//            var response = await service.GetRouteTemplatesAsync(request, cancellationToken);

//            // Assert
//            Assert.NotNull(response);
//            Assert.True(response.Result);
//            Assert.NotNull(response.SigningRouteTemplates);
//        }

//        [Fact]
//        public async Task GetRouteTemplatesAsync_WithInvalidRequest_ThrowsHttpRequestException()
//        {
//            // Arrange
//            var httpClient = new HttpClient();
//            var service = new RouteTemplateService(httpClient);
//            var request = new RouteTemplateRequest
//            {
//                Authorization = new AuthorizationContext
//                {
//                    Url = "https://example.com",
//                    ClientId = "123456",
//                    ApiToken = "abc123"
//                },
//                SigningObjectType = null // Invalid request
//            };
//            var cancellationToken = CancellationToken.None;

//            // Act & Assert
//            await Assert.ThrowsAsync<HttpRequestException>(async () => await service.GetRouteTemplatesAsync(request, cancellationToken));
//        }

//        [Fact]
//        public async Task GetRouteTemplatesAsync_WithErrorResponse_ThrowsHttpRequestException()
//        {
//            // Arrange
//            var httpClient = new HttpClient(new MockHttpMessageHandler(HttpStatusCode.BadRequest));
//            var service = new RouteTemplateService(httpClient);
//            var request = new RouteTemplateRequest
//            {
//                Authorization = new AuthorizationContext
//                {
//                    Url = "https://example.com",
//                    ClientId = "123456",
//                    ApiToken = "abc123"
//                },
//                SigningObjectType = SigningObjectType.DOCUMENT
//            };
//            var cancellationToken = CancellationToken.None;

//            // Act & Assert
//            await Assert.ThrowsAsync<HttpRequestException>(async () => await service.GetRouteTemplatesAsync(request, cancellationToken));
//        }
//    }

//    // MockHttpMessageHandler to simulate HTTP response with a specific status code
//    public class MockHttpMessageHandler : HttpMessageHandler
//    {
//        private readonly HttpStatusCode _statusCode;

//        public MockHttpMessageHandler(HttpStatusCode statusCode)
//        {
//            _statusCode = statusCode;
//        }

//        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
//        {
//            var response = new HttpResponseMessage(_statusCode);
//            return Task.FromResult(response);
//        }
//    }
//}
