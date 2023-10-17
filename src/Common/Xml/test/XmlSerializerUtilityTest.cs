// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Xml.Serialization;

namespace ParusRx.Xml.Tests;

public class XmlSerializerUtilityTests
{
    [Fact]
    public void XmlSerializerUtility_Serialize_ShouldReturnByteArray()
    {
        // Arrange
        var testRequest = new TestRequest
        {
            Name = "Test",
            Value = "TestValue"
        };

        // Act
        #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        byte[] xml = XmlSerializerUtility.Serialize(testRequest);
        #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        // Assert
        Assert.NotNull(xml);
    }

    [Fact]
    public void XmlSerializerUtility_Deserialize_ShouldReturnObject()
    {
        // Arrange
        var testRequest = new TestRequest
        {
            Name = "Test",
            Value = "TestValue"
        };

        #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        byte[] xml = XmlSerializerUtility.Serialize(testRequest);
        #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        // Act
        #pragma warning disable CS8604 // Possible null reference argument.
        var result = XmlSerializerUtility.Deserialize<TestRequest>(xml);
        #pragma warning restore CS8604 // Possible null reference argument.

        // Assert
        Assert.NotNull(result);
        Assert.Equal(testRequest.Name, result.Name);
        Assert.Equal(testRequest.Value, result.Value);
    }
}

[XmlRoot(ElementName = "TestRequest")]
public class TestRequest
{
    [XmlElement(ElementName = "Name")]
    public string? Name { get; set; }

    [XmlElement(ElementName = "Value")]
    public string? Value { get; set; }
}