// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using Microsoft.Extensions.Options;

namespace ParusRx.DaData.UnitTests;

public class SuggestPartyServiceTests
{
    private readonly Mock<HttpClient> _httpClientMock;
    private readonly DaDataSuggestPartyRequest _suggestionsRequest;

    public SuggestPartyServiceTests()
    {
        _httpClientMock = new Mock<HttpClient>();
        _suggestionsRequest = new DaDataSuggestPartyRequest
        {
            Authorization = new Authorization { AccessToken = "access_token" },
            SuggestPartyRequest = new SuggestPartyRequest { Query = "query" }
        };
    }

    [Fact]
    public async Task FindByIdAsync_ShouldReturnByteArray()
    {
        // Arrange
        var expected = new byte[] { 1, 2, 3 };
        var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK) { Content = new ByteArrayContent(expected) };
        _httpClientMock.Setup(x => x.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);

        var service = new SuggestPartyService(_httpClientMock.Object, Options.Create(new DaDataSettings { Suggestions = "" }));

        // Act
        var actual = await service.FindByIdAsync(_suggestionsRequest);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task FindByIdAsync_ShouldThrowHttpRequestException()
    {
        // Arrange
        var response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
        _httpClientMock.Setup(x => x.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);

        var service = new SuggestPartyService(_httpClientMock.Object, Options.Create(new DaDataSettings { Suggestions = "" }));

        // Act
        var exception = await Assert.ThrowsAsync<HttpRequestException>(() => service.FindByIdAsync(_suggestionsRequest));

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, exception.StatusCode);
    }
}
