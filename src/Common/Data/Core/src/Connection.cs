// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Data.Core;

/// <summary>
/// Represents a database connection.
/// </summary>
public sealed class Connection : IConnection
{
    /// <inheritdoc />
    public IConnectionFactory ConnectionFactory { get; set; } = null!;
}