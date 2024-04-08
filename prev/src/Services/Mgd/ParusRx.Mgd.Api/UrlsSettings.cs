// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api;

/// <summary>
/// Provides an URL settings.
/// </summary>
public class UrlsSettings
{
    /// <summary>
    /// Gets or sets the URL for the Mgd service.
    /// </summary>
    public string Mgd { get; set; }

    /// <summary>
    /// Gets or sets the URL for the Cipher service.
    /// </summary>
    public string Cipher { get; set; }

    /// <summary>
    /// Provides an operations for cipher service.
    /// </summary>
    public class CipherOperations
    {
        /// <summary>
        /// The signing method.
        /// </summary>
        public static string SignXml => $"/api/XmlDsig/sign";

        /// <summary>
        /// The verification method.
        /// </summary>
        public static string VerifyXml => $"/api/XmlDsig/verify";
    }
}
