// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using ParusRx.Storage;

namespace ParusRx.HRlink.FunctionalTests;

public class HRlinkApplication : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        var storeMock = new Mock<IParusRxStore>();
        storeMock.Setup(x => x.ReadDataRequestAsync(It.IsAny<string>())).ReturnsAsync(It.IsAny<byte[]>());
        storeMock.Setup(x => x.SaveDataResponseAsync(It.IsAny<string>(), It.IsAny<byte[]>())).Returns(Task.CompletedTask);
        storeMock.Setup(x => x.ErrorAsync(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.CompletedTask);

        builder.ConfigureServices(services =>
        {
            services.AddSingleton(storeMock.Object);
        });

        return base.CreateHost(builder);
    }
}
