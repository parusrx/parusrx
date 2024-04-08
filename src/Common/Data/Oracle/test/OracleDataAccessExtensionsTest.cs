// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using Oracle.ManagedDataAccess.Client;
using ParusRx.Data.Core;

namespace ParusRx.Data.Oracle.Tests;

public class OracleDataAccessExtensionsTest
{
    private const string ConnectionString = "User Id=system;Password=system;Data Source=localhost:1521/xe;";

    [Fact]
    public void UseOracle_ThrowsAnException_WhenConnectionIsNull()
    {
        // Arrange
        IConnection? connection = null;

        // Act
        var exception = Assert.Throws<ArgumentNullException>(() => connection!.UseOracle(ConnectionString));

        // Assert
        Assert.Equal("connection", exception.ParamName);
    }

    [Fact]
    public void UseOracle_ThrowsAnException_WhenConnectionStringIsNull()
    {
        // Arrange
        var connection = new Connection();

        // Act
        var exception = Assert.Throws<ArgumentNullException>(() => connection.UseOracle(null!));

        // Assert
        Assert.Equal("connectionString", exception.ParamName);
    }

    [Fact]
    public void UseOracle_SetsTheConnectionFactory()
    {
        // Arrange
        var connection = new Connection();

        // Act
        connection.UseOracle(ConnectionString);

        // Assert
        Assert.NotNull(connection.ConnectionFactory);
    }

    [Fact]
    public void UseOracle_SetsTheConnectionFactoryToOracle()
    {
        // Arrange
        var connection = new Connection();

        // Act
        connection.UseOracle(ConnectionString);

        // Assert
        Assert.IsType<ConnectionFactory<OracleConnection>>(connection.ConnectionFactory);
    }

    [Fact]
    public void AddDataAccess_RegisterOracleDataAccess()
    {
        // Arrange
        var serviceCollection = new ServiceCollection();

        // Act
        serviceCollection.AddDataAccess(c => c.UseOracle(ConnectionString));

        // Assert
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var connection = serviceProvider.GetRequiredService<IConnection>();
        Assert.NotNull(connection);
        Assert.IsType<OracleConnection>(connection.ConnectionFactory.CreateConnection());
    }
}