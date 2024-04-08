// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EArchive.Api.Models;

/// <summary>
/// Represens an incoming attachment.
/// </summary>
[XmlRoot(ElementName = "AttachmentIncoming")]
public class AttachmentIncoming
{
    /// <summary>
    /// Gets or sets the identifier of the incoming attachment.
    /// </summary>
    [JsonPropertyName("id")]
    [XmlElement(ElementName = "Id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the external identifier of the incoming attachment.
    /// </summary>
    [JsonPropertyName("extId")]
    [XmlElement(ElementName = "ExtId")]
    public string ExtId { get; set; }

    /// <summary>
    /// Gets or sets the file name of the incoming attachment.
    /// </summary>
    [JsonPropertyName("fileName")]
    [XmlElement(ElementName = "FileName")]
    public string FileName { get; set; }

    /// <summary>
    /// Gets or sets attachment file type of the incoming attachment.
    /// </summary>
    [JsonPropertyName("attachFileType")]
    [XmlElement(ElementName = "AttachFileType")]
    public string AttachFileType { get; set; }

    /// <summary>
    /// Gets or sets the attachment type of the incoming attachment.
    /// </summary>
    [JsonPropertyName("attachType")]
    [XmlElement(ElementName = "AttachType")]
    public string AttachType { get; set; }

    /// <summary>
    /// Gets or sets the attachment category of the incoming attachment.
    /// </summary>
    [JsonPropertyName("attachCategory")]
    [XmlElement(ElementName = "AttachCategory")]
    public string AttachCategory { get; set; }

    /// <summary>
    /// Gets or sets the author of the incoming attachment.
    /// </summary>
    [JsonPropertyName("author")]
    [XmlElement(ElementName = "Author")]
    public string Author { get; set; }

    /// <summary>
    /// Gets or sets the checksum of the incoming attachment.
    /// </summary>
    [JsonPropertyName("checksumm")]
    [XmlElement(ElementName = "Checksumm")]
    public string Checksumm { get; set; }

    /// <summary>
    /// Gets or sets the checksum algorithm of the incoming attachment.
    /// </summary>
    [JsonPropertyName("checksummAlg")]
    [XmlElement(ElementName = "ChecksummAlg")]
    public string ChecksummAlg { get; set; }

    private string _file;

    /// <summary>
    /// Gets or sets the Base64 encoded content of the incoming attachment.
    /// </summary>
    [JsonPropertyName("file")]
    [XmlElement(ElementName = "File")]
    public string File
    {
        get => _file;
        set
        {
            _file = value;

            if (!string.IsNullOrWhiteSpace(_file))
            {
                if (Checksumm == null)
                {
                    Checksumm = HashUtility.GetMD5Hash(_file);
                    ChecksummAlg = "MD5";
                }
            }
        }
    }

    /// <summary>
    /// Gets or sets the signatures of the incoming attachment.
    /// </summary>
    [JsonPropertyName("signatures")]
    [XmlArray(ElementName = "Signatures")]
    [XmlArrayItem(ElementName = "Signature")]
    public List<AttachmentSignatureIncoming> Signatures { get; set; } = new();
}
