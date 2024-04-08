// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

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