// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.Tests.Services;

public class ApplicationTypeServiceTests
{
    [Fact]
    public async Task GetApplicationTypesAsync_ReturnsApplicationTypeResponse_OnSuccess()
    {
        // Arrange
        var expectedResponse = new ApplicationTypeResponse
        {
            Result = true,
            ApplicationTypes = []
        };

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(expectedResponse)
            });

        var httpClient = new HttpClient(handlerMock.Object);
        var service = new ApplicationTypeService(httpClient);
        var request = new ApplicationTypeRequest
        {
            Authorization = new AuthorizationContext
            {
                Url = "https://test",
                ClientId = "client",
                ApiToken = "token"
            }
        };

        // Act
        var result = await service.GetApplicationTypesAsync(request);

        // Assert
        Assert.NotNull(result);
        Assert.True(result!.Result);
    }

    [Fact]
    public async Task GetApplicationTypesAsync_ThrowsHttpRequestException_OnError()
    {
        // Arrange
        var errorDetails = new ErrorDetails
        {
            ErrorMessage = "Error occurred",
            ErrorId = "123",
            ErrorCode = "ERR",
            OperationCode = "OP",
            ErrorData = new Dictionary<string, object?> { { "key", "value" } }
        };

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = JsonContent.Create(errorDetails)
            });

        var httpClient = new HttpClient(handlerMock.Object);
        var service = new ApplicationTypeService(httpClient);
        var request = new ApplicationTypeRequest
        {
            Authorization = new AuthorizationContext
            {
                Url = "https://test",
                ClientId = "client",
                ApiToken = "token"
            }
        };

        // Act & Assert
        var ex = await Assert.ThrowsAsync<HttpRequestException>(async () => await service.GetApplicationTypesAsync(request));
        Assert.Contains("Error occurred", ex.Message);
        Assert.Contains("Error ID: 123", ex.Message);
        Assert.Contains("Error Code: ERR", ex.Message);
        Assert.Contains("Operation Code: OP", ex.Message);
        Assert.Contains("key: value", ex.Message);
    }

    [Fact]
    public async Task GetApplicationTypesAsync_ThrowsArgumentNullException_WhenRequestIsNull()
    {
        // Arrange
        var httpClient = new HttpClient(new Mock<HttpMessageHandler>().Object);
        var service = new ApplicationTypeService(httpClient);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(async () => await service.GetApplicationTypesAsync(null!));
    }
}

// Dummy ErrorDetails for test compilation
public class ErrorDetails
{
    public string? ErrorMessage { get; set; }
    public string? ErrorId { get; set; }
    public string? ErrorCode { get; set; }
    public string? OperationCode { get; set; }
    public Dictionary<string, object?>? ErrorData { get; set; }
}
