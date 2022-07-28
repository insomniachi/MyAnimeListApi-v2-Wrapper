using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MalApi.JsonConverters;

public class RewatchValueConverter : JsonConverter<RewatchValue>
{
    public override RewatchValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var score = reader.GetInt32();
        return (RewatchValue)score;
    }

    public override void Write(Utf8JsonWriter writer, RewatchValue value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(((int)value).ToString());
    }
}
