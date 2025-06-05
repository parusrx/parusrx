// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

public enum ApplicationStatus
{
    [XmlEnum("DRAFT")]
    DRAFT,

    [XmlEnum("REJECTED")]
    REJECTED,

    [XmlEnum("SIGNED")]
    SIGNED,

    [XmlEnum("AWAITING_MY_SIGNING")]
    AWAITING_MY_SIGNING,

    [XmlEnum("AWAITING_OTHERS_SIGNING")]
    AWAITING_OTHERS_SIGNING,

    [XmlEnum("DELETED")]
    DELETED
}
