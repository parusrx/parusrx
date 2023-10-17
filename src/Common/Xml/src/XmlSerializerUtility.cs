// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ParusRx.Xml;

/// <summary>
/// Provides utility methods for XML serialization and deserialization.
/// </summary>
public static class XmlSerializerUtility
{
    /// <summary>
    /// Serializes the specified objects of <typeparamref name="T"/> type and writes the XML document to a byte array.
    /// </summary>
    /// <typeparam name="T">The type of the serializable object</typeparam>
    /// <param name="value">The serializable object.</param>
    /// <returns>The XML as byte array.</returns>
    public static byte[]? Serialize<T>(T value)
        where T : class
    {
        if (value == default(T))
        {
            return null;
        }

        var xmlSerializer = new XmlSerializer(typeof(T));

        using var memoryStream = new MemoryStream();
        using var xmlWriter = XmlWriter.Create(memoryStream, GetXmlWriterSettings());
        xmlSerializer.Serialize(xmlWriter, value);

        memoryStream.Flush();
        return memoryStream.ToArray();
    }

    /// <summary>
    /// Deserializes the XML document contained by the specified byte array.
    /// </summary>
    /// <typeparam name="T">The type of the deserializable object</typeparam>
    /// <param name="content">The XML content as byte array.</param>
    /// <returns>An object of <typeparamref name="T"/>.</returns>
    public static T? Deserialize<T>(byte[] content)
        where T : class
    {
        if (content.Length == 0)
        {
            return null;
        }

        var xmlSerializer = new XmlSerializer(typeof(T));
        using var memoryStream = new MemoryStream(content);

        return (T?)xmlSerializer.Deserialize(memoryStream);
    }

    private static XmlWriterSettings GetXmlWriterSettings()
        => new()
        {
            Encoding = new UTF8Encoding(false),
            Indent = true,
            OmitXmlDeclaration = false
        };
}