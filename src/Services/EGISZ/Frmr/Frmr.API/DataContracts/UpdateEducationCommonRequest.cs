// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.DataContracts;

[XmlRoot("updateEducationCommonRequest")]
public record UpdateEducationCommonRequest : BaseRequest
{
    [XmlElement("content")]
    public required EducationCommon Content { get; init; }
}
