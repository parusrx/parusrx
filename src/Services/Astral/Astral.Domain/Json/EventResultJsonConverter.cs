// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Astral.Domain.Json;

internal sealed class EventResultJsonConverter : JsonConverter<EventResult>
{
    public override EventResult Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        var id = string.Empty;
        var code = string.Empty;
        var parent = string.Empty;
        var errors = Array.Empty<string>();
        var created = DateTime.MinValue;
        var consumer = Array.Empty<string>();
        var producer = string.Empty;
        var data = new object();

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                return new EventResult
                {
                    Id = id,
                    Code = code,
                    Parent = parent,
                    Errors = errors,
                    Created = created,
                    Consumer = consumer,
                    Producer = producer,
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
                case "errors":
                    errors = JsonSerializer.Deserialize<string[]>(ref reader, options) ?? Array.Empty<string>();
                    break;
                case "created":
                    created = reader.GetDateTime();
                    break;
                case "consumer": 
                    consumer = JsonSerializer.Deserialize<string[]>(ref reader, options) ?? Array.Empty<string>();
                    break;
                case "producer":
                    producer = reader.GetString() ?? string.Empty;
                    break;
                case "data":
                    var type = code switch
                    {
                        "poa.create.unified.request" => typeof(PoaCreateUnifiedRequest),
                        "poa.create.unified.response" => typeof(PoaCreateUnifiedResponse),
                        _ => throw new NotSupportedException()
                    };
                    data = JsonSerializer.Deserialize(ref reader, type, options) ?? new object();
                    break;

                default:
                    reader.Skip();
                    break;
            }
        }

        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, EventResult value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("id", value.Id);
        writer.WriteString("code", value.Code);
        writer.WriteString("parent", value.Parent);
        writer.WritePropertyName("errors");
        JsonSerializer.Serialize(writer, value.Errors, options);
        writer.WriteString("created", value.Created);
        writer.WritePropertyName("consumer");
        JsonSerializer.Serialize(writer, value.Consumer, options);
        writer.WriteString("producer", value.Producer);
        writer.WritePropertyName("data");
        JsonSerializer.Serialize(writer, value.Data, options);
        writer.WriteEndObject();
    }
}
