// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.Tests.Services;

public class FileServiceTests
{
    [Fact]
    public async Task UploadAsync_WithValidRequest_ReturnsFilesUploadResponse()
    {
        // Arrange
        var request = new FilesUploadRequest
        {
            Authorization = new AuthorizationContext 
            { 
                Url = "https://demo.hr-link.ru", 
                ClientId = "78DB35C3-64E4-4D06-B34D-793070E970C6", 
                ApiToken = "81255B76-7F18-46E2-93C0-7ED60BE814F9" 
            },
            Files = [new FileDto { FileName = "file.txt", Content = "SGVsbG8gV29ybGQ=" }]
        };
        var expectedResponse = new FilesUploadResponse 
        { 
            Result = true, 
            Files = [new FileItem { Id = "d7dfeb89-2883-4dfb-8d89-86b7cafa3827", Name = "file.txt", CreatedDate = DateTime.UtcNow }] 
        };

        var responseMessage = new HttpResponseMessage(HttpStatusCode.OK) { Content = JsonContent.Create(expectedResponse) };

        var httpMessageHandlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(responseMessage)
            .Verifiable();
        var httpClient = new HttpClient(httpMessageHandlerMock.Object);

        var fileService = new FileService(httpClient);

        // Act
        var result = await fileService.UploadAsync(request);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedResponse.Files.Length, result.Files.Length);
        Assert.Equal(expectedResponse.Files.First().Id, result.Files.First().Id);
        Assert.Equal(expectedResponse.Files.First().Name, result.Files.First().Name);
    }

    [Fact]
    public async Task UploadAsync_WithNullRequest_ThrowsArgumentNullException()
    {
        // Arrange
        FilesUploadRequest? request = null;

        var fileService = new FileService(new HttpClient());

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(async () => await fileService.UploadAsync(request!));
    }
}