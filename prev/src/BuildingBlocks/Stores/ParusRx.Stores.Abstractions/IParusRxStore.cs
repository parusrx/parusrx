// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Threading.Tasks;

namespace ParusRx.Stores.Abstractions;

/// <summary>
/// Provides methods allowing to manage the metadata stored in a database.
/// </summary>
public interface IParusRxStore
{
    /// <summary>
    /// Retrieves the metadata associated with a request.
    /// </summary>
    /// <param name="id">The unique identifier associated with the request.</param>
    /// <returns>A <see cref="Task"/> that contains the data request..</returns>
    Task<byte[]> ReadDataRequestAsync(string id);

    /// <summary>
    /// Save the response metadata associated with a request.
    /// </summary>
    /// <param name="id">The unique identifier associated with the request.</param>
    /// <param name="data">The response data fo bytes.</param>
    /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
    Task SaveDataResponseAsync(string id, byte[] data);

    /// <summary>
    /// Set the error associated with a request.
    /// </summary>
    /// <param name="id">The unique identifier associated with the request.</param>
    /// <param name="message">The error message.</param>
    /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
    Task ErrorAsync(string id, string message);
}
