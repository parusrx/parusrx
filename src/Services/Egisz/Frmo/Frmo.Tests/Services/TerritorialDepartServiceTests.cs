﻿// // Copyright (c) The Parus RX Authors. All rights reserved.
// // Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Tests.Services;

public class TerritorialDepartServiceTests
{
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private readonly TerritorialDepartService _service;

    public TerritorialDepartServiceTests()
    {
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();

        var httpClient = new HttpClient(_httpMessageHandlerMock.Object)
        {
            BaseAddress = new Uri("https://ips.test.egisz.rosminzdrav.ru/4f52d90e921a0/")
        };

        _service = new TerritorialDepartService(httpClient);
    }

    [Fact]
    public async Task ListAsync_ShouldReturnTerritorialDepartResponse_WhenRequestIsSuccessful()
    {
        // Arrange
        var queryParameters = new Dictionary<string, string?> { { "key", "value" } };
        var expectedResponse = new ListResponse<TerritorialDepart>();
        
        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
            });

        // Act
        var response = await _service.ListAsync(queryParameters, CancellationToken.None);

        // Assert
        Assert.Equal(expectedResponse.RequestId, response.RequestId);
        Assert.Equal(expectedResponse.Message, response.Message);
        Assert.Equal(expectedResponse.Content, response.Content);
    }

    [Fact]
    public async Task ListAsync_ShouldThrowHttpResponseException_WhenRequestIsNotSuccessful()
    {
        // Arrange
        var queryParameters = new Dictionary<string, string?> { { "key", "value" } };
        var expectedResponse = new ProblemDetails(
            DateTimeOffset.Parse("2023-11-20T12:00:00+03:00"),
            404,
            "Not Found",
            "The requested resource was not found.");
        
        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
            });

        // Act
        var exception = await Assert.ThrowsAsync<HttpResponseException>(async () => await _service.ListAsync(queryParameters, CancellationToken.None));


        // Assert
        Assert.IsType<ProblemDetails>(exception.Value);
        Assert.Equal(expectedResponse, (ProblemDetails)exception.Value);
    }

    [Fact]
    public async Task GetAsync_ShouldReturnTerritorialDepartResponse_WhenRequestIsSuccessful()
    {
        // Arrange
        var queryParameters = new Dictionary<string, string?> { { "key", "value" } };
        var expectedResponse = new SingleResponse<TerritorialDepart>();
        
        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
            });

        // Act
        var response = await _service.GetAsync(queryParameters, CancellationToken.None);

        // Assert
        Assert.Equal(expectedResponse.RequestId, response.RequestId);
        Assert.Equal(expectedResponse.Message, response.Message);
        Assert.Equal(expectedResponse.Content, response.Content);
    }

    [Fact]
    public async Task GetAsync_ShouldThrowHttpResponseException_WhenRequestIsNotSuccessful()
    {
        // Arrange
        var queryParameters = new Dictionary<string, string?> { { "key", "value" } };
        var expectedResponse = new ProblemDetails(
            DateTimeOffset.Parse("2023-11-20T12:00:00+03:00"),
            404,
            "Not Found",
            "The requested resource was not found.");
        
        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
            });

        // Act
        var exception = await Assert.ThrowsAsync<HttpResponseException>(async () => await _service.GetAsync(queryParameters, CancellationToken.None));

        // Assert
        Assert.IsType<ProblemDetails>(exception.Value);
        Assert.Equal(expectedResponse, (ProblemDetails)exception.Value);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnCreateTerritorialDepartResponse_WhenRequestIsSuccessful()
    {
        // Arrange
        var queryParameters = new Dictionary<string, string?> { { "key", "value" } };
        var territorialDepart = new TerritorialDepart();
        var expectedResponse = new SingleResponse<Entity>
        {
            RequestId = Guid.NewGuid().ToString(),
            Content = new Entity { EntityId = Guid.NewGuid().ToString() }
        };

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
            });

        // Act
        var response = await _service.CreateAsync(queryParameters, territorialDepart, CancellationToken.None);

        // Assert
        Assert.Equal(expectedResponse, response);
    }

    [Fact]
    public async Task CreateAsync_ShouldThrowHttpResponseException_WhenRequestIsNotSuccessful()
    {
        // Arrange
        var queryParameters = new Dictionary<string, string?> { { "key", "value" } };
        var territorialDepart = new TerritorialDepart();
        var expectedResponse = new ProblemDetails(
            DateTimeOffset.Parse("2023-11-20T12:00:00+03:00"),
            404,
            "Not Found",
            "The requested resource was not found.");

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
            });

        // Act
        var exception = await Assert.ThrowsAsync<HttpResponseException>(async () => await _service.CreateAsync(queryParameters, territorialDepart, CancellationToken.None));

        // Assert
        Assert.IsType<ProblemDetails>(exception.Value);
        Assert.Equal(expectedResponse, (ProblemDetails)exception.Value);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnUpdateTerritorialDepartResponse_WhenRequestIsSuccessful()
    {
        // Arrange
        var queryParameters = new Dictionary<string, string?> { { "key", "value" } };
        var territorialDepart = new TerritorialDepart();
        var expectedResponse = new DefaultResponse
        {
            RequestId = Guid.NewGuid().ToString()
        };

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
            });

        // Act
        var response = await _service.UpdateAsync(queryParameters, territorialDepart, CancellationToken.None);

        // Assert
        Assert.Equal(expectedResponse, response);
    }

    [Fact]
    public async Task UpdateAsync_ShouldThrowHttpResponseException_WhenRequestIsNotSuccessful()
    {
        // Arrange
        var queryParameters = new Dictionary<string, string?> { { "key", "value" } };
        var territorialDepart = new TerritorialDepart();
        var expectedResponse = new ProblemDetails(
            DateTimeOffset.Parse("2023-11-20T12:00:00+03:00"),
            404,
            "Not Found",
            "The requested resource was not found.");

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
            });

        // Act
        var exception = await Assert.ThrowsAsync<HttpResponseException>(async () => await _service.UpdateAsync(queryParameters, territorialDepart, CancellationToken.None));

        // Assert
        Assert.IsType<ProblemDetails>(exception.Value);
        Assert.Equal(expectedResponse, (ProblemDetails)exception.Value);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnDeleteTerritorialDepartResponse_WhenRequestIsSuccessful()
    {
        // Arrange
        var queryParameters = new Dictionary<string, string?> { { "key", "value" } };
        var expectedResponse = new DefaultResponse();

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
            });

        // Act
        var response = await _service.DeleteAsync(queryParameters, CancellationToken.None);

        // Assert
        Assert.Equal(expectedResponse, response);
    }

    [Fact]
    public async Task DeleteAsync_ShouldThrowHttpResponseException_WhenRequestIsNotSuccessful()
    {
        // Arrange
        var queryParameters = new Dictionary<string, string?> { { "key", "value" } };
        var expectedResponse = new ProblemDetails(
            DateTimeOffset.Parse("2023-11-20T12:00:00+03:00"),
            404,
            "Not Found",
            "The requested resource was not found.");

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
            });

        // Act
        var exception = await Assert.ThrowsAsync<HttpResponseException>(async () => await _service.DeleteAsync(queryParameters, CancellationToken.None));

        // Assert
        Assert.IsType<ProblemDetails>(exception.Value);
        Assert.Equal(expectedResponse, (ProblemDetails)exception.Value);
    }
}