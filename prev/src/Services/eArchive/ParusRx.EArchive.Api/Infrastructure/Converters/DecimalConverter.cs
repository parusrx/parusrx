// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EArchive.Api.Infrastructure.Converters;

/// <summary>
/// Represents a JSON.NET converter able to convert decimal value.
/// </summary>
public class DecimalConverter : JsonConverter<decimal>
{
    /// <inheritdoc/>
    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var stringValue = reader.GetString();
            if (decimal.TryParse(stringValue, out var value))
            {
                return value;
            }
        }
        else if (reader.TokenType == JsonTokenType.Number)
        {
            return reader.GetDecimal();
        }

        throw new JsonException();
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value);
    }
}
