// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Astral.Domain.Json;

internal sealed class EventJsonConverter : JsonConverter<EventMeta>
{
    public override EventMeta? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        var id = string.Empty;
        var code = string.Empty;
        var parent = string.Empty;
        var consumers = Array.Empty<string>();
        var producer = string.Empty;
        var created = DateTime.MinValue;
        var data = new object();

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                return new EventMeta
                {
                    Id = id,
                    Code = code,
                    Parent = parent,
                    Consumer = consumers,
                    Producer = producer,
                    Created = created,
                    Data = data
                };
            }

            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            var propertyName = reader.GetString();
            reader.Read();

            switch (propertyName)
            {
                case "id":
                    id = reader.GetString() ?? string.Empty;
                    break;
                case "code":
                    code = reader.GetString() ?? string.Empty;
                    break;
                case "parent":
                    parent = reader.GetString() ?? string.Empty;
                    break;
                case "consumer":
                    consumers = JsonSerializer.Deserialize<string[]>(ref reader, options) ?? Array.Empty<string>();
                    break;
                case "producer":
                    producer = reader.GetString() ?? string.Empty;
                    break;
                case "created":
                    created = reader.GetDateTime();
                    break;
                case "data":
                    var type = code switch
                    {
                        "poa.create.unified.request" => typeof(PoaCreateUnifiedRequest),
                        "poa.create.unified.response" => typeof(PoaCreateUnifiedResponse),
                        _ => throw new NotSupportedException()
                    };
                    data = JsonSerializer.Deserialize<object>(ref reader, options) ?? new object();
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, EventMeta value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("id", value.Id);
        writer.WriteString("code", value.Code);
        writer.WriteString("parent", value.Parent);
        writer.WritePropertyName("consumer");
        JsonSerializer.Serialize(writer, value.Consumer, options);
        writer.WriteString("producer", value.Producer);
        writer.WriteString("created", value.Created);
        writer.WritePropertyName("data");
        JsonSerializer.Serialize(writer, value.Data, options);
        writer.WriteEndObject();
    }
}
