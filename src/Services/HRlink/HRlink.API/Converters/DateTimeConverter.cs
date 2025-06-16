// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Text.Json;

namespace ParusRx.HRlink.API.Converters;

internal sealed class DateTimeConverter : JsonConverter<DateTime>
{
    private const string DateFormat = "yyyy-MM-ddTHH:mm:ss.fffZ"; // ISO 8601 format

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String && reader.TryGetDateTime(out DateTime dateTime))
        {
            return dateTime;
        }
        throw new JsonException($"Expected a string in ISO 8601 format, but got {reader.TokenType}.");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToUniversalTime().ToString(DateFormat, System.Globalization.CultureInfo.InvariantCulture));
    }
}
