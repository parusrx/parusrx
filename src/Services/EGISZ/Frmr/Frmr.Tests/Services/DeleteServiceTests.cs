// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.Tests;

public class DeleteServiceTests
{
    private readonly Mock<IOptionsSnapshot<FrmrSettings>> _settingsMock;
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private readonly PersonService _service;

    public DeleteServiceTests()
    {
        _settingsMock = new Mock<IOptionsSnapshot<FrmrSettings>>();
        _settingsMock.Setup(s => s.Value).Returns(new FrmrSettings { Url = "https://ips.test.egisz.rosminzdrav.ru/4f52d90e921a0" });

        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();

        _service = new PersonService(new HttpClient(_httpMessageHandlerMock.Object), _settingsMock.Object);
    }

    [Fact]
    public async Task GetAsync_ShouldReturnGetPersonResponse_WhenRequestIsSuccessful()
    {
        // Arrange
        var queryParameters = new Dictionary<string, string?> { { "key", "value" } };
        var expectedResponse = new GetPersonResponse();

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
            });

        // Act
        var response = await _service.GetAsync(queryParameters);

        // Assert
        Assert.Equal(expectedResponse, response);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnCreatePersonResponse_WhenRequestIsSuccessful()
    {
        // Arrange
        var queryParameters = new Dictionary<string, string?> { { "key", "value" } };
        var person = new Person();
        var expectedResponse = new CreatePersonResponse
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
        var response = await _service.CreateAsync(queryParameters, person);

        // Assert
        Assert.Equal(expectedResponse, response);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnUpdatePersonResponse_WhenRequestIsSuccessful()
    {
        // Arrange
        var queryParameters = new Dictionary<string, string?> { { "key", "value" } };
        var person = new Person();
        var expectedResponse = new UpdatePersonResponse
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
        var response = await _service.UpdateAsync(queryParameters, person);

        // Assert
        Assert.Equal(expectedResponse, response);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnDeletePersonResponse_WhenRequestIsSuccessful()
    {
        // Arrange
        var queryParameters = new Dictionary<string, string?> { { "key", "value" } };
        var expectedResponse = new DeletePersonResponse();

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
            });

        // Act
        var response = await _service.DeleteAsync(queryParameters);

        // Assert
        Assert.Equal(expectedResponse, response);
    }
}
