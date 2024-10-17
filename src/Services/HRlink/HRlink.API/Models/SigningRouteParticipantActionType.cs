// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents the type of an action performed by a participant in a signing route.
/// </summary>
public enum SigningRouteParticipantActionType
{
    /// <summary>
    /// The signing.
    /// </summary>
    [XmlEnum("SIGNING")]
    SIGNING,

    /// <summary>
    /// The approving.
    /// </summary>
    [XmlEnum("APPROVING")]
    APPROVING,

    /// <summary>
    /// The receiving.
    /// </summary>
    [XmlEnum("RECEIVING")]
    RECEIVING,

    /// <summary>
    /// The processing.
    /// </summary>
    [XmlEnum("PROCESSING")]
    PROCESSING
}
