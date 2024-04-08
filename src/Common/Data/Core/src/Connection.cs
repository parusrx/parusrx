// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Data.Core;

/// <summary>
/// Represents a database connection.
/// </summary>
public sealed class Connection : IConnection
{
    /// <inheritdoc />
    public IConnectionFactory ConnectionFactory { get; set; } = null!;
}