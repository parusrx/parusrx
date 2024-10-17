// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents the method of signing on a route.
/// </summary>
public enum RouteSigningType
{
    /// <summary>
    /// The PEP.
    /// </summary>
    [XmlEnum("SES")]
    SES,

    /// <summary>
    /// The cloud UNEP.
    /// </summary>
    [XmlEnum("CLOUD_NQES")]
    CLOUD_NQES,

    /// <summary>
    /// The Qualified Electronic Signature.
    /// </summary>
    [XmlEnum("QES")]
    QES,

    /// <summary>
    /// Through the portal "Work in Russia".
    /// </summary>
    [XmlEnum("PRR")]
    PRR,

    /// <summary>
    /// The government key.
    /// </summary>
    [XmlEnum("GOV_KEY")]
    GOV_KEY,

    /// <summary>
    /// Any suitable method.
    /// </summary>
    [XmlEnum("ANY_APPLICABLE")]
    ANY_APPLICABLE
}
