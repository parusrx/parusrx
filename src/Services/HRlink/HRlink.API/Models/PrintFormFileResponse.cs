// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Xml;

namespace ParusRx.HRlink.API.Models;

[XmlRoot("printFormFileResponse")]
public sealed record PrintFormFileResponse
{
    [XmlElement("fileName")]
    public string? FileName { get; set; }

    [XmlIgnore]
    public string? Data { get; set; }

    [XmlElement("data")]
    public XmlCDataSection? DataCData
    {
        get => Data is not null ? new XmlDocument().CreateCDataSection(Data) : null;
        set => Data = value?.Value;
    }

}
