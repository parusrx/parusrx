// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using Npgsql;
using ParusRx.Data.Core;

namespace ParusRx.Data.PostgreSQL.Tests;

public class PostgreSqlDataAccessExtensionsTest
{
    private const string ConnectionString = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=postgres;";

    [Fact]
    public void UseNpgsql_ThrowsAnException_WhenConnectionIsNull()
    {
        // Arrange
        IConnection? connection = null;

        // Act
        var exception = Assert.Throws<ArgumentNullException>(() => connection!.UseNpgsql(ConnectionString));

        // Assert
        Assert.Equal("connection", exception.ParamName);
    }

    [Fact]
    public void UseNpgsql_ThrowsAnException_WhenConnectionStringIsNull()
    {
        // Arrange
        var connection = new Connection();

        // Act
        var exception = Assert.Throws<ArgumentNullException>(() => connection.UseNpgsql(null!));

        // Assert
        Assert.Equal("connectionString", exception.ParamName);
    }

    [Fact]
    public void UseNpgsql_SetsTheConnectionFactory()
    {
        // Arrange
        var connection = new Connection();

        // Act
        connection.UseNpgsql(ConnectionString);

        // Assert
        Assert.NotNull(connection.ConnectionFactory);
    }

    [Fact]
    public void UseNpgsql_SetsTheConnectionFactoryToPostgreSQL()
    {
        // Arrange
        var connection = new Connection();

        // Act
        connection.UseNpgsql(ConnectionString);

        // Assert
        Assert.IsType<ConnectionFactory<NpgsqlConnection>>(connection.ConnectionFactory);
    }

    [Fact]
    public void AddDataAccess_RegisterPostgreSQLDataAccess()
    {
        // Arrange
        var serviceCollection = new ServiceCollection();

        // Act
        serviceCollection.AddDataAccess(c => c.UseNpgsql(ConnectionString));

        // Assert
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var connection = serviceProvider.GetRequiredService<IConnection>();
        Assert.NotNull(connection);
        Assert.IsType<NpgsqlConnection>(connection.ConnectionFactory.CreateConnection());
    }
}