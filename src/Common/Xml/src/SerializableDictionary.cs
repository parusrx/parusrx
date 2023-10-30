// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ParusRx.Xml;

public sealed class SerializableDictionary : Dictionary<string, string?>, IXmlSerializable
{
    /// <inheritdoc/>
    public XmlSchema? GetSchema() => null;

    /// <inheritdoc/>
    public void ReadXml(XmlReader reader)
    {
        var wasEmpty = reader.IsEmptyElement;
        reader.Read();

        if (wasEmpty)
        {
            return;
        }

        while (reader.NodeType != XmlNodeType.EndElement)
        {
            if (reader.NodeType != XmlNodeType.Element)
            {
                reader.Read();
                continue;
            }
            // if (reader.NodeType == XmlNodeType.Element)
            // {
                string key = reader.LocalName;
                string? value = reader.ReadElementContentAsString();

                Add(key, value);
            // }
        }

        reader.ReadEndElement();
    }

    /// <inheritdoc/>
    public void WriteXml(XmlWriter writer)
    {
        foreach(var kvp in this.Where(kvp => kvp.Value is not null))
        {
            writer.WriteElementString(kvp.Key, kvp.Value);
        }
    }
}
