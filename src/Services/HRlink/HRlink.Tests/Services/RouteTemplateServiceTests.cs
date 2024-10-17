// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Tests.Services;

public class RouteTemplateServiceTests
{
    [Fact]
    public async Task GetRouteTemplatesAsync_WithNullRequest_ThrowsArgumentNullException()
    {
        // Arrange
        RouteTemplateRequest? request = null;
        Mock<HttpClient> httpClient = new(MockBehavior.Loose);

        RouteTemplateService service = new(httpClient.Object);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(async () => await service.GetRouteTemplatesAsync(request!));
    }

    [Fact]
    public async Task GetRouteTemplatesAsync_WithValidRequest_ReturnsRouteTemplateResponse()
    {
        RouteTemplateRequest request = new RouteTemplateRequest
        {
            Authorization = new AuthorizationContext
            {
                Url = "https://demo.hr-link.ru",
                ClientId = "78DB35C3-64E4-4D06-B34D-793070E970C6",
                ApiToken = "81255B76-7F18-46E2-93C0-7ED60BE814F9"
            }
        };

        HttpClient httpClient = CreateHttpClientWithMockHandler((request, cancellationToken) =>
        {
            Assert.Equal("https://demo.hr-link.ru/api/v1/clients/78DB35C3-64E4-4D06-B34D-793070E970C6/routeTemplates", request.RequestUri?.ToString());

            HttpResponseMessage response = new(HttpStatusCode.OK)
            {
                Content = JsonContent.Create(new RouteTemplateResponse
                {
                    Result = true,
                    SigningRouteTemplates =
                    [
                        new SigningRouteTemplate
                        {
                            Id = "1",
                            Name = "Route 1"
                        }
                    ]
                })
            };

            return Task.FromResult(response);
        });

        RouteTemplateService service = new(httpClient);

        // Act
        RouteTemplateResponse? response = await service.GetRouteTemplatesAsync(request);

        // Assert
        Assert.IsType<RouteTemplateResponse>(response);
        Assert.NotNull(response);
    }

    [Theory]
    [InlineData(HttpStatusCode.Unauthorized, """{ "result": false, "ErrorId": "D7DFEB89-2883-4DFB-8D89-86B7CAFA3827", "ErrorMessage": "The specified API token is invalid.", "ErrorCode": "11.006", "OperationCode": "11.100" }""")]
    [InlineData(HttpStatusCode.BadRequest, """{ "result": false, "ErrorId": "D7DFEB89-2883-4DFB-8D89-86B7CAFA3827", "ErrorMessage": "The specified JSON does not match the expected format.", "ErrorCode": "11.021", "OperationCode": "11.181", "ErrorData": { "path": "documents[0]" } }""")]
    [InlineData(HttpStatusCode.Forbidden, """{ "result": false, "ErrorId": "D7DFEB89-2883-4DFB-8D89-86B7CAFA3827", "ErrorMessage": "The specified client is not allowed to perform this operation.", "ErrorCode": "10.000", "OperationCode": "11.082", "ErrorData": { "permission": "ROUTE_TEMPLATES" } }""")]
    [InlineData(HttpStatusCode.InternalServerError, """{ "result": false, "ErrorId": "D7DFEB89-2883-4DFB-8D89-86B7CAFA3827", "ErrorMessage": "An error occurred while processing the request.", "ErrorCode": "11.000", "OperationCode": "21.100" }""")]
    public async Task GetRouteTemplatesAsync_WithErrorResponse_ThrowsHttpRequestException(HttpStatusCode statusCode, string content)
    {
        RouteTemplateRequest request = new RouteTemplateRequest
        {
            Authorization = new AuthorizationContext
            {
                Url = "https://demo.hr-link.ru",
                ClientId = "78DB35C3-64E4-4D06-B34D-793070E970C6",
                ApiToken = "81255B76-7F18-46E2-93C0-7ED60BE814F9"
            }
        };
        HttpClient httpClient = CreateHttpClientWithMockHandler((request, cancellationToken) =>
        {
            HttpResponseMessage response = new(statusCode)
            {
                Content = new StringContent(content)
            };
            return Task.FromResult(response);
        });
        RouteTemplateService service = new(httpClient);
        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(async () => await service.GetRouteTemplatesAsync(request));
    }


    private static HttpClient CreateHttpClientWithMockHandler(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> valueFunction)
    {
        Mock<HttpMessageHandler> mockHttpMessageHandler = new(MockBehavior.Strict);
        mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .Returns(valueFunction)
            .Verifiable();

        return new HttpClient(mockHttpMessageHandler.Object);
    }
}
