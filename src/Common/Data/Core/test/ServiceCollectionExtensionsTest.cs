// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Data.Core.Tests;

public class ServiceCollectionExtensionsTest
{
    [Fact]
    public void AddDataAccess_ThrowsAnException_WhenServiceCollectionIsNull()
    {
        // Arrange
        IServiceCollection? serviceCollection = null;

        // Act
        var exception = Assert.Throws<ArgumentNullException>(() => serviceCollection!.AddDataAccess());

        // Assert
        Assert.Equal("services", exception.ParamName);
    }
}