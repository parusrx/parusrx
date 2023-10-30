// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API;

[XmlRoot("createEducationCommonRequest")]
public record CreateEducationCommonRequest : BaseRequest
{
    [XmlElement("content")]
    public required EducationCommon Content { get; init; }
}
