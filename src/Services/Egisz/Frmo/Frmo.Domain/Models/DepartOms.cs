// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

[XmlRoot("oms")]
public record DepartOms
{
    [XmlElement("omsMarkId")]
    [JsonPropertyName("omsMarkId")]
    public string? OmsMarkId { get; init; }

    [XmlElement("codeOktmo")]
    [JsonPropertyName("codeOktmo")]
    public string? CodeOktmo { get; init; }

    [XmlElement("omsId")]
    [JsonPropertyName("omsId")]
    public string? OmsId { get; init; }

    [XmlElement("beginDate")]
    [JsonPropertyName("beginDate")]
    public DateTime? BeginDate { get; init; }

    [XmlElement("endDate")]
    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }

    [XmlArray("stacSublevels")]
    [XmlArrayItem("stacSublevelsItem")]
    [JsonPropertyName("stacSublevels")]
    public StacSublevel[]? StacSublevels { get; init; }

    [XmlArray("dayStacSublevels")]
    [XmlArrayItem("dayStacSublevelsItem")]
    [JsonPropertyName("dayStacSublevels")]
    public StacSublevel[]? DayStacSublevels { get; init; }

    [XmlArray("ambSublevels")]
    [XmlArrayItem("ambSublevelsItem")]
    [JsonPropertyName("ambSublevels")]
    public StacSublevel[]? AmbSublevels { get; init; }
}
