// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Text;

namespace ParusRx.HRlink.Tests.Services;

public class DocumentServiceTests
{
    [Fact]
    public async Task CreateDocumentGroupAsync_WithNullRequest_ThrowsArgumentNullException()
    {
        // Arrange
        CreateDocumentGroupRequest? request = null;
        Mock<HttpClient> httpClientMock = new(MockBehavior.Loose);

        var documentService = new DocumentService(httpClientMock.Object);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(async () => await documentService.CreateDocumentGroupAsync(request!));
    }

    [Fact]
    public async Task CreateDocumentGroupAsync_WithValidRequest_ReturnsCreateDocumentGroupResponse()
    {
        // Arrange
        var createDocumentGroupRequest = new CreateDocumentGroupRequest
        {
            Authorization = new AuthorizationContext 
            { 
                Url = "https://demo.hr-link.ru", 
                ClientId = "78DB35C3-64E4-4D06-B34D-793070E970C6", 
                ApiToken = "81255B76-7F18-46E2-93C0-7ED60BE814F9" 
            },
            DocumentGroup = new DocumentGroupRequestItem 
            { 
                Name = "Test",
                CreatorExternalId = "1",
                Documents =
                [
                    new() 
                    { 
                        ExternalId = "1"
                    } 
                ]
            }
        };
        var httpClient = CreateHttpClientWithMockHandler((request, cancellationToken) => 
        {
            Assert.Equal("https://demo.hr-link.ru/api/v1/clients/78DB35C3-64E4-4D06-B34D-793070E970C6/documentGroups", request.RequestUri?.ToString());
            var sentRequest = JsonSerializer.Deserialize<DocumentGroupRequestItem>(request.Content?.ReadAsStringAsync(cancellationToken)?.Result!);

            Assert.Equal(createDocumentGroupRequest.DocumentGroup.Name, sentRequest?.Name);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = JsonContent.Create(new CreateDocumentGroupResponse 
                { 
                    Result = true, 
                    DocumentGroup = new DocumentGroupResultItem 
                    { 
                        Id = "D7DFEB89-2883-4DFB-8D89-86B7CAFA3827", 
                        Documents = 
                        [
                            new DocumentResultItem 
                            { 
                                Id = "S7DFAB99-48W3-5SF1-90G9-36AS2OFA3828"
                            } 
                        ]
                    } 
                })
            };

            return Task.FromResult(response);
        });

        var documentService = new DocumentService(httpClient);

        // Act
        var result = await documentService.CreateDocumentGroupAsync(createDocumentGroupRequest);

        // Assert
        Assert.IsType<CreateDocumentGroupResponse>(result);
        Assert.NotNull(result);
    }

    [Theory]
    [InlineData(HttpStatusCode.Unauthorized, """{ "result": false, "ErrorId": "D7DFEB89-2883-4DFB-8D89-86B7CAFA3827", "ErrorMessage": "The specified API token is invalid.", "ErrorCode": "11.006", "OperationCode": "11.100" }""")]
    [InlineData(HttpStatusCode.BadRequest, """{ "result": false, "ErrorId": "D7DFEB89-2883-4DFB-8D89-86B7CAFA3827", "ErrorMessage": "The specified JSON does not match the expected format.", "ErrorCode": "11.021", "OperationCode": "11.181", "ErrorData": { "path": "documents[0]" } }""")]
    [InlineData(HttpStatusCode.Forbidden, """{ "result": false, "ErrorId": "D7DFEB89-2883-4DFB-8D89-86B7CAFA3827", "ErrorMessage": "The specified client is not allowed to perform this operation.", "ErrorCode": "10.000", "OperationCode": "11.082", "ErrorData": { "permission": "CREATE_DOCUMENT" } }""")]
    [InlineData(HttpStatusCode.InternalServerError, """{ "result": false, "ErrorId": "D7DFEB89-2883-4DFB-8D89-86B7CAFA3827", "ErrorMessage": "An error occurred while processing the request.", "ErrorCode": "11.000", "OperationCode": "21.100" }""")]
    public async Task CreateDocumentGroupAsync_WithInvalidRequest_ThrowsHttpRequestException(HttpStatusCode code, string content)
    {
        // Arrange
        var createDocumentGroupRequest = new CreateDocumentGroupRequest
        {
            Authorization = new AuthorizationContext 
            { 
                Url = "https://demo.hr-link.ru", 
                ClientId = "78DB35C3-64E4-4D06-B34D-793070E970C6", 
                ApiToken = "81255B76-7F18-46E2-93C0-7ED60BE814F9" 
            },
            DocumentGroup = new DocumentGroupRequestItem 
            { 
                Name = "Test",
                CreatorExternalId = "1",
                Documents =
                [
                    new() 
                    { 
                        ExternalId = "1"
                    } 
                ]
            }
        };

        var httpClient = CreateHttpClientWithMockHandler((request, cancellationToken) => 
        {
            Assert.Equal("https://demo.hr-link.ru/api/v1/clients/78DB35C3-64E4-4D06-B34D-793070E970C6/documentGroups", request.RequestUri?.ToString());
            var sentRequest = JsonSerializer.Deserialize<DocumentGroupRequestItem>(request.Content?.ReadAsStringAsync(cancellationToken)?.Result!);

            Assert.Equal(createDocumentGroupRequest.DocumentGroup.Name, sentRequest?.Name);

            var response = new HttpResponseMessage(code)
            {
                Content = new StringContent(content, Encoding.UTF8, "application/json")
            };

            return Task.FromResult(response);
        });

        var documentService = new DocumentService(httpClient);

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(async () => await documentService.CreateDocumentGroupAsync(createDocumentGroupRequest));
    }

    private static HttpClient CreateHttpClientWithMockHandler(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> valueFunction)
    {
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .Returns(valueFunction)
            .Verifiable();

        return new HttpClient(mockHttpMessageHandler.Object);
    }
}
