// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Reflection;
using System.Runtime.Serialization;

namespace ParusRx.Astral.Domain.Json;

public class JsonStringEnumMemberConverter<T> : JsonConverter<T> where T : Enum
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
        {
            throw new JsonException();
        }

        var enumValue = reader.GetString();
        if (enumValue == null)
        {
            throw new JsonException();
        }

        var enumType = typeof(T);
        var member = enumType.GetMembers().FirstOrDefault(m => m.GetCustomAttribute<EnumMemberAttribute>()?.Value == enumValue);
        if (member == null)
        {
            throw new JsonException();
        }

        return (T)Enum.Parse(enumType, member.Name);
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        var enumType = typeof(T);
        var member = enumType.GetMember(value.ToString()).FirstOrDefault();
        if (member == null)
        {
            throw new JsonException();
        }

        var enumMember = member.GetCustomAttribute<EnumMemberAttribute>();
        if (enumMember == null)
        {
            throw new JsonException();
        }

        writer.WriteStringValue(enumMember.Value);
    }
}
