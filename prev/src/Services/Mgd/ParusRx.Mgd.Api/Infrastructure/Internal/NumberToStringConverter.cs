// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Infrastructure.Internal;

/// <summary>
/// Represents a JSON.NET converter able to convert number value to string.
/// </summary>
internal class NumberToStringConverter : JsonConverter<string>
{
    /// <inheritdoc/>
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            var numberValue = reader.GetInt64();
            return numberValue.ToString();
        }
        else if (reader.TokenType == JsonTokenType.String)
        {
            return reader.GetString();
        }
        else
        {
            throw new JsonException();
        }
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }
}
