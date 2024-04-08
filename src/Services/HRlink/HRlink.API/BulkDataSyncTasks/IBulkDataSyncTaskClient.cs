// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.BulkDataSyncTasks;

/// <summary>
/// Defines methods for interacting with the HRlink Bulk Data Sync Task API.
/// </summary>
public interface IBulkDataSyncTaskClient
{
    /// <summary>
    /// Creates a new Bulk Data Sync Task.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="baseUri">The base URI.</param>
    /// <param name="clientId">The client identifier.</param>
    /// <param name="apiToken">The API token.</param>
    /// <param name="request">The request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="CreateBulkDataSyncTaskResponse"/> representing the response from the API.</returns>
    Task<CreateBulkDataSyncTaskResponse?> CreateBulkDataSyncTaskAsync<TValue>(string baseUri, string clientId, string apiToken, CreateBulkDataSyncTaskRequest<TValue> request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the status of a Bulk Data Sync Task.
    /// </summary>
    /// <param name="baseUri">The base URI.</param>
    /// <param name="clientId">The client identifier.</param>
    /// <param name="apiToken">The API token.</param>
    /// <param name="id">The identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="BulkDataSyncTaskResponse"/> representing the response from the API.</returns>
    Task<BulkDataSyncTaskResponse?> GetFullStatusBulkDataSyncTaskByIdAsync(string baseUri, string clientId, string apiToken, string id, CancellationToken cancellationToken = default);
}