// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EArchive.Api.Models;

/// <summary>
/// Represents the incoming signature of an attachment.
/// </summary>
[XmlRoot(ElementName = "AttachmentSignatureIncoming")]
public class AttachmentSignatureIncoming
{
    /// <summary>
    /// Gets or sets the identifier of the signature.
    /// </summary>
    [JsonPropertyName("id")]
    [XmlElement(ElementName = "Id")]
    public string Id { get; set; }

    private string _file;

    /// <summary>
    /// Gets or sets the Base64 encoded content of the signature.
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
    /// Gets or sets the external identifier of the signature.
    /// </summary>
    [JsonPropertyName("extId")]
    [XmlElement(ElementName = "ExtId")]
    public string ExtId { get; set; }

    /// <summary>
    /// Gets or sets the file name of the signature.
    /// </summary>
    [JsonPropertyName("filename")]
    [XmlElement(ElementName = "FileName")]
    public string FileName { get; set; }

    /// <summary>
    /// Gets or sets the certificate of the signature.
    /// </summary>
    [JsonPropertyName("certificate")]
    [XmlElement(ElementName = "Certificate")]
    public string Certificate { get; set; }

    /// <summary>
    /// Gets or sets the format of the signature.
    /// </summary>
    [JsonPropertyName("format")]
    [XmlElement(ElementName = "Format")]
    public string Format { get; set; }

    /// <summary>
    /// Gets or sets the sign date.
    /// </summary>
    [JsonPropertyName("signdate")]
    [XmlElement(ElementName = "SignDate")]
    public DateTime? SignDate { get; set; }

    /// <summary>
    /// Gets or sets the checksum of the signature.
    /// </summary>
    [JsonPropertyName("checksumm")]
    [XmlElement(ElementName = "Checksumm")]
    public string Checksumm { get; set; }

    /// <summary>
    /// Gets or sets the checksum algorithm of the signature.
    /// </summary>
    [JsonPropertyName("checksummAlg")]
    [XmlElement(ElementName = "ChecksummAlg")]
    public string ChecksummAlg { get; set; }
}
