using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MalApi.JsonConverters;

public class PriorityConverter : JsonConverter<Priority>
{
    public override Priority Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var score = reader.GetInt32();
        return (Priority)score;
    }

    public override void Write(Utf8JsonWriter writer, Priority value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(((int)value).ToString());
    }
}
