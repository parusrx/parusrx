// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Xml;
using System.Xml.Serialization;

namespace ParusRx.Xml.Tests;

public class SerializableDictionaryTest
{
    [Fact]
    public void CanSeriaLize()
    {
        // Arrange
        string xml = $"""
            <?xml version="1.0" encoding="utf-16"?>
            <SerializableDictionary>
              <key1>value1</key1>
              <key2>value2</key2>
            </SerializableDictionary>
            """;

        var dictionary = new SerializableDictionary
        {
            { "key1", "value1" },
            { "key2", "value2" },
            { "key3", null }
        };
        var serializer = new XmlSerializer(typeof(SerializableDictionary));
        var writer = new StringWriter();

        // Act
        serializer.Serialize(writer, dictionary);

        // Assert
        Assert.Equal(writer.ToString(), xml); 
   }

    [Fact]
    public void TestDeserialization()
    {
        // Arrange
        string xml = $"""
            <?xml version="1.0" encoding="utf-16"?>
            <SerializableDictionary>
              <key1>value1</key1>
              <key2>value2</key2>
            </SerializableDictionary>
            """;
        var serializer = new XmlSerializer(typeof(SerializableDictionary));
        var reader = XmlReader.Create(new StringReader(xml));

        // Act
        var dictionary = (SerializableDictionary?)serializer.Deserialize(reader);

        // Assert
        Assert.NotNull(dictionary);
        Assert.Equal("value1", dictionary["key1"]);
        Assert.Equal("value2", dictionary["key2"]);
    }
}