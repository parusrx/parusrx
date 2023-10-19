// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.Tests;

public class ListPagedOrganizationIntegrationEventHandlerTests
{
    private readonly Mock<IParusRxStore> _storeMock;
    private readonly Mock<IOrganizationService> _serviceMock;
    private readonly Mock<ILogger<ListPagedOrganizationIntegrationEventHandler>> _loggerMock;

    public ListPagedOrganizationIntegrationEventHandlerTests()
    {
        _storeMock = new Mock<IParusRxStore>();
        _serviceMock = new Mock<IOrganizationService>();
        _loggerMock = new Mock<ILogger<ListPagedOrganizationIntegrationEventHandler>>();
    }

    [Fact]
    public async Task HandleAsync_WithValidRequest_SaveDataResponse()
    {
        // Arrange
        int orgTypeId = 1;
        int offset = 0;
        int limit = 2;
        int total = 3;

        MqIntegrationEvent @event = new(Guid.NewGuid().ToString());

        ListPagedOrganizationRequest request = new()
        {
            Parameters = new()
            {
                OrgTypeId = orgTypeId,
                Offset = offset,
                Limit = limit
            }
        };

        ListPagedOrganizationResponse response = new()
        {
            RequestId = Guid.NewGuid().ToString(),
            Message = null,
            Offset = offset,
            Limit = limit,
            Total = total,
            Content = new()
            {
                new Organization
                {
                    Oid = "1.2.643.5.1.13.13.12.2.78.6258"
                },
                new Organization
                {
                    Oid = "1.2.643.5.1.13.13.12.2.78.9235"
                }
            }
        };

        _storeMock.Setup(s => s.ReadDataRequestAsync(@event.Body)).ReturnsAsync(XmlSerializerUtility.Serialize(request)!);
        _storeMock.Setup(s => s.SaveDataResponseAsync(@event.Body, It.IsAny<byte[]>())).Returns(Task.CompletedTask);
        _serviceMock.Setup(s => s.ListPagedAsync(request.Parameters.OrgTypeId, request.Parameters.Offset, request.Parameters.Limit, It.IsAny<CancellationToken>())).ReturnsAsync(response);

        var handler = new ListPagedOrganizationIntegrationEventHandler(_storeMock.Object, _serviceMock.Object, _loggerMock.Object);

        // Act
        await handler.HandleAsync(@event);

        // Assert
        _storeMock.Verify(s => s.ReadDataRequestAsync(@event.Body), Times.Once());
        _storeMock.Verify(s => s.SaveDataResponseAsync(@event.Body, It.IsAny<byte[]>()), Times.Once());
        _serviceMock.Verify(s => s.ListPagedAsync(request.Parameters.OrgTypeId, request.Parameters.Offset, request.Parameters.Limit, It.IsAny<CancellationToken>()), Times.Once());
    }

    [Fact]
    public async Task HandleAsync_WithException_SaveErrorAndLogError()
    {
        // Arrange
        MqIntegrationEvent @event = new(Guid.NewGuid().ToString());

        _storeMock.Setup(s => s.ReadDataRequestAsync(@event.Body)).ThrowsAsync(new InvalidOperationException());

        var handler = new ListPagedOrganizationIntegrationEventHandler(_storeMock.Object, _serviceMock.Object, _loggerMock.Object);

        // Act
        await handler.HandleAsync(@event);

        // Assert
        _storeMock.Verify(s => s.ReadDataRequestAsync(@event.Body), Times.Once());
        _storeMock.Verify(s => s.ErrorAsync(@event.Body, It.IsAny<string>()), Times.Once());
        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((o, t) => o.ToString()!.Contains($"Error handling integration event: {@event.Id} - {@event}")),
                It.IsAny<Exception>(),
                (Func<It.IsAnyType, Exception?, string>)It.IsAny<object>()), 
            Times.Once);
    }
}
