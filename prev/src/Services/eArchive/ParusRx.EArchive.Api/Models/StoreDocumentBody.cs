// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EArchive.Api.Models;

/// <summary>
/// Represents the body of a stored document.
/// </summary>
[XmlRoot(ElementName = "StoreDocumentBody")]
public class StoreDocumentBody
{
    /// <summary>
    /// Gets or sets the document name.
    /// </summary>
    [JsonPropertyName("name")]
    [XmlElement(ElementName = "Name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the document number.
    /// </summary>
    [JsonPropertyName("docNumber")]
    [XmlElement(ElementName = "DocNumber")]
    public string DocNumber { get; set; }

    /// <summary>
    /// Gets or sets the control sum of the document.
    /// </summary>
    [JsonPropertyName("docSumm")]
    [XmlElement(ElementName = "DocSumm")]
    public string DocSumm { get; set; }

    /// <summary>
    /// Gets or sets the document date.
    /// </summary>
    [JsonPropertyName("docDate")]
    [XmlElement(ElementName = "DocDate")]
    public DateTime DocDate { get; set; }

    /// <summary>
    /// Gets or sets the expiration date of the document.
    /// </summary>
    [JsonPropertyName("dtEnd")]
    [XmlElement(ElementName = "DtEnd")]
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Gets or sets the external identifier of the document.
    /// </summary>
    [JsonPropertyName("extId")]
    [XmlElement(ElementName = "ExtId")]
    public string ExtId { get; set; }

    /// <summary>
    /// Gets or sets the document type of the document.
    /// </summary>
    [JsonPropertyName("docType")]
    [XmlElement(ElementName = "DocType")]
    public DocType DocType { get; set; }

    /// <summary>
    /// Gets or sets the organization of the document.
    /// </summary>
    [JsonPropertyName("organisation")]
    [XmlElement(ElementName = "Organisation")]
    public Organisation Organisation { get; set; }

    /// <summary>
    /// Gets or sets the source system of the document.
    /// </summary>
    [JsonPropertyName("srcSystem")]
    [XmlElement(ElementName = "SrcSystem")]
    public string SrcSystem { get; set; }

    /// <summary>
    /// Gets or sets whether the document is automatically re-signing.
    /// </summary>
    [JsonPropertyName("automaticResigning")]
    [XmlElement(ElementName = "AutomaticResigning")]
    public bool AutomaticResigning { get; set; }

    /// <summary>
    /// Gets or sets the attachments of the document.
    /// </summary>
    [JsonPropertyName("attachs")]
    [XmlArray(ElementName = "Attachs")]
    [XmlArrayItem(ElementName = "Attach")]
    public List<AttachmentIncoming> Attachs { get; set; } = new();
}
