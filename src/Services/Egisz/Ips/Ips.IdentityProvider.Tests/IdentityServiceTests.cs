// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using ParusRx.Egisz.Ips.IdentityProvider;

namespace ParusRx.Egisz.Ips.IdentityProvider.Tests;

public class IdentityServiceTests
{
    [Fact]
    public async Task GetAccessTokenAsync_ReturnsAccessTokenFromCache_WhenCacheIsNotEmpty()
    {
        // Arrange
        var expectedToken = new AccessToken("access_token", DateTimeOffset.UtcNow.AddMinutes(5), "Bearer");

        var cache = new MemoryDistributedCache(Options.Create(new MemoryDistributedCacheOptions()));
        await cache.SetAsync("ips_token", JsonSerializer.SerializeToUtf8Bytes(expectedToken), new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        });

        var settingsMock = new Mock<IOptionsSnapshot<IdentitySettings>>();
        settingsMock.Setup(s => s.Value).Returns(new IdentitySettings { Url = "http://ips-identity-provider.com", TokenCacheExpiration = TimeSpan.FromMinutes(5) });

        var identityService = new IdentityService(new HttpClient(), cache, settingsMock.Object);

        // Act
        var token = await identityService.GetAccessTokenAsync();

        // Assert
        Assert.NotNull(token);
        Assert.Equal(expectedToken.Token, token.Token);
        Assert.Equal(expectedToken.ExpiresIn, token.ExpiresIn);
    }

    [Fact]
    public async Task GetAccessTokenAsync_ReturnsAccessTokenFromApi_WhenCacheIsEmpty()
    {
        // Arrange
        var expectedToken = new AccessToken("access_token", DateTimeOffset.UtcNow.AddMinutes(5), "Bearer");
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = JsonContent.Create(expectedToken)
        };

        var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(response);

        var cache = new MemoryDistributedCache(Options.Create(new MemoryDistributedCacheOptions()));
        var settingsMock = new Mock<IOptionsSnapshot<IdentitySettings>>();
        settingsMock.Setup(s => s.Value).Returns(new IdentitySettings { Url = "http://ips-identity-provider.com", TokenCacheExpiration = TimeSpan.FromMinutes(5) });

        var identityService = new IdentityService(new HttpClient(httpMessageHandlerMock.Object), cache, settingsMock.Object);

        // Act
        var token = await identityService.GetAccessTokenAsync();

        // Assert
        Assert.NotNull(token);
        Assert.Equal(expectedToken.Token, token.Token);
        Assert.Equal(expectedToken.ExpiresIn, token.ExpiresIn);

        httpMessageHandlerMock.Protected().Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
    }
}