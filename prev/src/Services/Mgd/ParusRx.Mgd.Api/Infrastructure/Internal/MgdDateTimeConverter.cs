// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Infrastructure.Internal;

/// <summary>
/// Represents a JSON.NET converter able to convert date time value.
/// </summary>
internal class MgdDateTimeConverter : JsonConverter<DateTime>
{
    private const string Format = "yyyy-MM-dd_HH-mm-ss";

    /// <inheritdoc/>
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => DateTime.ParseExact(reader.GetString(), Format, CultureInfo.InvariantCulture, DateTimeStyles.None);

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString(Format, CultureInfo.InvariantCulture));
}
