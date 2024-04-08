// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Infrastructure;

/// <summary>
/// Represents the result of a <see cref="IMgdIntegrationService.GetMessageAsync"/> operation.
/// </summary>
public class MgdIntegrationResult
{
    /// <summary>
    /// Returns an <see cref="MgdIntegrationResult"/>indicating a successful message retrieval operation.
    /// </summary>
    public static MgdIntegrationResult Success => new() { Succeeded = true };

    /// <summary>
    /// Creates an <see cref="SmtpResult"/> indicating a failed message retrieval operation, with an error if applicable.
    /// </summary>
    /// <param name="error">An error which caused the operation to fail.</param>
    /// <returns>A <see cref="MgdIntegrationResult"/> representing a failed message retrieval operation.</returns>
    public static MgdIntegrationResult Failed(string error) => new() { Succeeded = false, Error = error };

    /// <summary>
    /// Whether if the operation succeeded or not.
    /// </summary>
    public bool Succeeded { get; protected set; }

    /// <summary>
    /// An error that occurred during the message retrieval operation.
    /// </summary>
    public string Error { get; protected set; }
}
