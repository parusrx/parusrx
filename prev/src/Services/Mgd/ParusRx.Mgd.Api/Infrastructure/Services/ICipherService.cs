// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Infrastructure.Services;

/// <summary>
/// Represents a service that provides cryptography methods.
/// </summary>
public interface ICipherService
{
    /// <summary>
    /// Sign XML.
    /// </summary>
    /// <param name="data">The data to be signed.</param>
    /// <returns>Returns a signature.</returns>
    Task<string> SignXmlAsync(SignData data);

    /// <summary>
    /// XML signature verification.
    /// </summary>
    /// <param name="data">The data to be verified.</param>
    /// <returns>
    ///   <see langword="true"/> if <paramref name="data"/> is verified; otherwise, <see langword="false"/>.
    /// </returns>
    Task<bool> VerifyXmlAsync(VerifyData data);
}
