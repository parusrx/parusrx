// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.Domain;

public record PersonQualification
{
    [XmlElement("qulificationId")]
    [JsonPropertyName("qulificationId")]
    public string? QualificationId { get; init; }

    [XmlElement("qualifyCategoryId")]
    [JsonPropertyName("qualifyCategoryId")]
    public int QualifyCategoryId { get; init; }

    [XmlElement("qualifyCategoryName")]
    [JsonPropertyName("qualifyCategoryName")]
    public string? QualifyCategoryName { get; init; }

    [XmlElement("beginDate")]
    [JsonPropertyName("beginDate")]
    public DateTime BeginDate { get; init; }

    [XmlElement("endDate")]
    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }

    [XmlElement("specId")]
    [JsonPropertyName("specId")]
    public int? SpecId { get; init; }

    [XmlElement("specName")]
    [JsonPropertyName("specName")]
    public string? SpecName { get; init; }

    [XmlElement("fedPostId")]
    [JsonPropertyName("fedPostId")]
    public int? FedPostId { get; init; }

    [XmlElement("fedPostName")]
    [JsonPropertyName("fedPostName")]
    public string? FedPostName { get; init; }

    [XmlElement("postId")]
    [JsonPropertyName("postId")]
    public int? PostId { get; init; }

    [XmlElement("postName")]
    [JsonPropertyName("postName")]
    public string? PostName { get; init; }
}
