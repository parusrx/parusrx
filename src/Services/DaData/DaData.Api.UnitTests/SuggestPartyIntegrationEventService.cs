// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Text;
using Microsoft.Extensions.Logging;
using ParusRx.DaData.Api.Integration;
using ParusRx.EventBus.Events;
using ParusRx.Storage.Abstractions;

namespace ParusRx.DaData.Api.UnitTests;

public class SuggestPartyIntegrationEventServiceTests
{
    private readonly Mock<IParusRxStore> _storeMock;
    private readonly Mock<ISuggestPartyService> _suggestPartyServiceMock;
    private readonly Mock<ILogger<SuggestPartyIntegrationEventService>> _loggerMock;
    private readonly SuggestPartyIntegrationEventService _service;

    public SuggestPartyIntegrationEventServiceTests()
    {
        _storeMock = new Mock<IParusRxStore>();
        _suggestPartyServiceMock = new Mock<ISuggestPartyService>();
        _loggerMock = new Mock<ILogger<SuggestPartyIntegrationEventService>>();

        _service = new SuggestPartyIntegrationEventService(_storeMock.Object, _suggestPartyServiceMock.Object, _loggerMock.Object);
    }

    [Fact]
    public async Task FindPartyByIdAsync_ShouldCallStoreReadDataRequestAsync_WhenInvoked()
    {
        // Arrange
        var integrationEvent = new IntegrationEvent { Payload = "123" };
        var cancellationToken = new CancellationToken();

        // Act
        await _service.FindPartyByIdAsync(integrationEvent, cancellationToken);

        // Assert
        _storeMock.Verify(x => x.ReadDataRequestAsync("123"), Times.Once);
    }

    [Fact]
    public async Task FindPartyByIdAsync_ShouldCallSuggestPartyServiceFindByIdAsync_WhenInvoked()
    {
        // Arrange
        var integrationEvent = new IntegrationEvent { Payload = "123" };
        var cancellationToken = new CancellationToken();
        var data = "<DaDataSuggestPartyRequest><Name>Test Company</Name></DaDataSuggestPartyRequest>";
        _storeMock.Setup(x => x.ReadDataRequestAsync("123")).ReturnsAsync(Encoding.UTF8.GetBytes(data));

        // Act
        await _service.FindPartyByIdAsync(integrationEvent, cancellationToken);

        // Assert
        _suggestPartyServiceMock.Verify(x => x.FindByIdAsync(It.IsAny<DaDataSuggestPartyRequest>(), cancellationToken), Times.Once);
    }

    [Fact]
    public async Task FindPartyByIdAsync_ShouldCallStoreSaveDataResponseAsync_WhenInvoked()
    {
        // Arrange
        var integrationEvent = new IntegrationEvent { Payload = "123" };
        var cancellationToken = new CancellationToken();
        var data = "<DaDataSuggestPartyRequest><Name>Test Company</Name></DaDataSuggestPartyRequest>";
        var response = "<DaDataSuggestPartyResponse><Suggestions><Item><Value>Test Company</Value></Item></Suggestions></DaDataSuggestPartyResponse>";
        _storeMock.Setup(x => x.ReadDataRequestAsync("123")).ReturnsAsync(Encoding.UTF8.GetBytes(data));
        _suggestPartyServiceMock.Setup(x => x.FindByIdAsync(It.IsAny<DaDataSuggestPartyRequest>(), cancellationToken)).ReturnsAsync(Encoding.UTF8.GetBytes(response));

        // Act
        await _service.FindPartyByIdAsync(integrationEvent, cancellationToken);

        // Assert
        _storeMock.Verify(x => x.SaveDataResponseAsync("123", Encoding.UTF8.GetBytes(response)), Times.Once);
    }
}
