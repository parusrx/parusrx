// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

public enum SignatureType
{
    [XmlEnum("CLOUD_QES")]
    CLOUD_QES,

    [XmlEnum("CLOUD_NQES")]
    CLOUD_NQES,

    [XmlEnum("EXTERNAL_QES")]
    EXTERNAL_QES,

    [XmlEnum("GOV_KEY")]
    GOV_KEY,

    [XmlEnum("PRR")]
    PRR,

    [XmlEnum("SES")]
    SES
}