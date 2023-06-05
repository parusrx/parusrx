// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Moq.Protected;

using ParusRx.HRLink.EmployeeRole.API;
using ParusRx.HRLink.EmployeeRole.UnitTests.Helpers;

namespace ParusRx.HRLink.EmployeeRole.UnitTests;

public class EmployeeRoleClientTests
{
    [Fact]
    public async Task GetEmployeeRolesAsync_ReturnsEmployeeRolesResponse()
    {
        // Arrange
        const string url = "https://demo.hr-link.ru";
        var expectedResponse = new EmployeeRolesResponse
        {
            Result = true,
            EmployeeRoles = new List<EmployeeRoleItem>
            {
                new EmployeeRoleItem
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    Description = "Administrator"
                }
            }
        };

        var httpMessageHandler = HttpClientHelper.GetResults(expectedResponse);
        var httpClient = new HttpClient(httpMessageHandler.Object);
        var client = new EmployeeRoleClient(httpClient);

        // Act
        var response = await client.GetEmployeeRolesAsync(url, "3D95E05F-4B24-49B4-8369-A3CC58AFB1F6");

        // Assert
        Assert.NotNull(response);
        httpMessageHandler
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(0),
                ItExpr.Is<HttpRequestMessage>(
                req => req.Method == HttpMethod.Get &&
                req.RequestUri == new Uri(url)),
            ItExpr.IsAny<CancellationToken>()
            );
    }

    [Fact]
    public async Task GetEmployeeRolesAsync_ThrowsArgumentNullException_WhenUrlIsNullOrEmpty()
    {
        // Arrange
        var url = string.Empty;
        var apiToken = "3D95E05F-4B24-49B4-8369-A3CC58AFB1F6";
        var httpClient = new Mock<HttpClient>();
        var client = new EmployeeRoleClient(httpClient.Object);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetEmployeeRolesAsync(url, apiToken));
    }

    [Fact]
    public async Task GetEmployeeRolesAsync_ThrowsArgumentNullException_WhenApiTokenIsNullOrEmpty()
    {
        // Arrange
        var url = "https://demo.hr-link.ru";
        var apiToken = string.Empty;
        var httpClient = new Mock<HttpClient>();
        var client = new EmployeeRoleClient(httpClient.Object);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetEmployeeRolesAsync(url, apiToken));
    }
}