// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using ParusRx.HRLink.API.EmployeeRoles;

namespace ParusRx.HRLink.UnitTests;

public class EmployeeRolesIntegrationEventHandlerTests
{
    private readonly Mock<IParusRxStore> _mockStore;
    private readonly Mock<IEmployeeRolesClient> _mockClient;
    private readonly Mock<ILogger<EmployeeRolesIntegrationEventHandler>> _mockLogger;
    private readonly EmployeeRolesIntegrationEventHandler _handler;
    private readonly IntegrationEvent _event;
    private readonly EmployeeRolesRequest _request;
    private readonly EmployeeRolesResponse _response;

    public EmployeeRolesIntegrationEventHandlerTests()
    {
        _mockStore = new Mock<IParusRxStore>();
        _mockClient = new Mock<IEmployeeRolesClient>();
        _mockLogger = new Mock<ILogger<EmployeeRolesIntegrationEventHandler>>();

        _handler = new EmployeeRolesIntegrationEventHandler(_mockStore.Object, _mockClient.Object, _mockLogger.Object);

        _event = new IntegrationEvent { Payload = "1000" };

        _request = new EmployeeRolesRequest
        {
            Url = "https://demo.hr-link.ru",
            ApiToken = "81255B76-7F18-46E2-93C0-7ED60BE814F9"
        };

        _response = new EmployeeRolesResponse
        {
            Result = true,
            EmployeeRoles = new List<EmployeeRole>
            {
                new EmployeeRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    Description = "Description"
                }
            }
        };
    }

    [Fact]
    public async Task HandleAsync_Should_Call_ReadDataRequestAsync_With_Correct_Id()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;

        // Act
        await _handler.HandleAsync(_event, cancellationToken);

        // Assert
        _mockStore.Verify(x => x.ReadDataRequestAsync(_event.Payload), Times.Once);
    }

    [Fact]
    public async Task HandleAsync_Should_Call_GetEmployeeRolesAsync_With_Correct_Parameters()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        var data = XmlSerializerUtility.Serialize(_request);
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
        _mockStore.Setup(x => x.ReadDataRequestAsync(_event.Payload)).ReturnsAsync(data);
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
        _mockClient.Setup(x => x.GetEmployeeRolesAsync(_request.Url, _request.ApiToken, cancellationToken)).ReturnsAsync(_response);

        // Act
        await _handler.HandleAsync(_event, cancellationToken);

        // Assert
        _mockClient.Verify(x => x.GetEmployeeRolesAsync(_request.Url, _request.ApiToken, cancellationToken), Times.Once);
    }

    [Fact]
    public async Task HandleAsync_Should_Call_SaveDataResponseAsync_With_Correct_Data()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        var data = XmlSerializerUtility.Serialize(_request);
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
        _mockStore.Setup(x => x.ReadDataRequestAsync(_event.Payload)).ReturnsAsync(data);
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
        _mockClient.Setup(x => x.GetEmployeeRolesAsync(_request.Url, _request.ApiToken, cancellationToken)).ReturnsAsync(_response);
        var employeeRoleItems = _response.EmployeeRoles?.AsEmployeeRoleItems() ?? new();
        var response = XmlSerializerUtility.Serialize(employeeRoleItems) ?? Array.Empty<byte>();
        _mockStore.Setup(x => x.SaveDataResponseAsync(_event.Payload, response)).Returns(Task.CompletedTask);

        // Act
        await _handler.HandleAsync(_event, cancellationToken);

        // Assert
        _mockStore.Verify(x => x.SaveDataResponseAsync(_event.Payload, response), Times.Once);
    }

    [Fact]
    public async Task HandleAsync_Should_Call_Store_ErrorAsync_When_Exception_Occurs()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        var expectedException = new Exception("Test exception");
        _mockStore.Setup(x => x.ReadDataRequestAsync(_event.Payload)).ThrowsAsync(expectedException);

        // Act
        await _handler.HandleAsync(_event, cancellationToken);

        // Act & Assert
        _mockStore.Verify(x => x.ErrorAsync(_event.Payload, expectedException.Message), Times.Once);
        _mockLogger.Verify(x => x.Log(
            It.Is<LogLevel>(l => l == LogLevel.Error),
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString() == "Test exception"),
            It.IsAny<Exception>(),
            It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Never);
    }
}
